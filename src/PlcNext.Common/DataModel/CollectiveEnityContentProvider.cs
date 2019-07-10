﻿#region Copyright
///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) Phoenix Contact GmbH & Co KG
//  This software is licensed under Apache-2.0
//
///////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlcNext.Common.Tools;

namespace PlcNext.Common.DataModel
{
    internal class CollectiveEnityContentProvider : IEntityContentProvider
    {
        private readonly IEnumerable<IEntityContentProvider> contentResolvers;
        private CycleChecker<Resolution> cycleChecker;
        private CycleChecker<Resolution> canCycleChecker;

        public CollectiveEnityContentProvider(IEnumerable<IEntityContentProvider> contentResolvers)
        {
            this.contentResolvers = contentResolvers;
        }

        public bool CanResolve(Entity owner, string key, bool fallback = false)
        {
            if (cycleChecker?.HasItem(new Resolution(owner, key)) == true)
            {
                //break cycles before they form
                return false;
            }
            using (canCycleChecker = canCycleChecker?.SpawnChild() ?? new CycleChecker<Resolution>(ExceptionTexts.ContentProviderCycle,
                                                                                             () => canCycleChecker = null))
            {
                Resolution resolution = new Resolution(owner, key);
                canCycleChecker.AddItem(resolution);
                bool result = contentResolvers.Any(r => r.CanResolve(owner, key, false));
                if (!result)
                {
                    canCycleChecker.RemoveAfter(resolution);
                    result = contentResolvers.Any(r => r.CanResolve(owner, key, true));
                }

                return result;
            }
        }

        public Entity Resolve(Entity owner, string key, bool fallback = false)
        {
            using (cycleChecker = cycleChecker?.SpawnChild()?? new CycleChecker<Resolution>(ExceptionTexts.ContentProviderCycle,
                                                                                            () => cycleChecker = null))
            {
                cycleChecker.AddItem(new Resolution(owner, key));
                fallback = false;
                IEntityContentProvider provider = contentResolvers.FirstOrDefault(r => r.CanResolve(owner, key, fallback));
                if (provider == null)
                {
                    fallback = true;
                    provider = contentResolvers.FirstOrDefault(r => r.CanResolve(owner, key, fallback));
                }
                if (provider == null)
                {
                    throw new ContentProviderException(key, owner);
                }

                return provider.Resolve(owner, key, fallback);
            }
        }

        private class Resolution : IEquatable<Resolution>
        {
            private readonly Entity entity;

            public override string ToString()
            {
                return $"Entity: {entity}, Key: {key}";
            }

            private readonly string key;

            public Resolution(Entity entity, string key)
            {
                this.entity = entity;
                this.key = key;
            }

            public bool Equals(Resolution other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(entity, other.entity) && string.Equals(key, other.key);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Resolution)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((entity != null ? entity.GetHashCode() : 0) * 397) ^ (key != null ? key.GetHashCode() : 0);
                }
            }

            public static bool operator ==(Resolution left, Resolution right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Resolution left, Resolution right)
            {
                return !Equals(left, right);
            }
        }
    }
}