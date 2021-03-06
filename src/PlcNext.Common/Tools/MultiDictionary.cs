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

namespace PlcNext.Common.Tools
{
    internal class MultiDictionary<TKey, TValue>
    {
        private Dictionary<TKey, List<TValue>> data = new Dictionary<TKey, List<TValue>>();

        public IEnumerable<TKey> Keys => data.Keys;

        public void Add(TKey key, TValue value)
        {
            if (data.ContainsKey(key))
            {
                if (!data[key].Contains(value)) // do not allow duplicate values
                    data[key].Add(value);
            }
            else
                data.Add(key, new List<TValue>() { value });
        }

        public List<TValue> Get(TKey key)
        {
            if (data.ContainsKey(key))
                return data[key];
            else
                return new List<TValue>();
        }

        public bool Remove(TKey key, TValue value)
        {
            bool result = false;
            if (data.ContainsKey(key))
            {
                result = data[key].Remove(value);
                if (!data[key].Any())
                {
                    data.Remove(key);
                }
            }
            return result;
        }
    }
}
