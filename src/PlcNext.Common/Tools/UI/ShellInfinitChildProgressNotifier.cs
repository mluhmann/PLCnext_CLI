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
using System.Text;
using System.Timers;
using ShellProgressBar;

namespace PlcNext.Common.Tools.UI
{
    internal class ShellInfinitChildProgressNotifier : ShellChildProgressNotifier
    {
        private readonly Timer updateTimer = new Timer(Constants.InfinitProgressUpdateTime) { AutoReset = true };
        private readonly int progressStep;

        public ShellInfinitChildProgressNotifier(string startMessage, ProgressBarOptions options, ShellProgressNotifierBase parent) : base(Constants.ProgressMaxResolution, startMessage, options, parent)
        {
            updateTimer.Elapsed += UpdateTimerOnElapsed;
            progressStep = Math.Max((int)(Constants.ProgressMaxResolution / Constants.InfinitProgressResolution * Scaling), 1);
        }

        protected override ProgressBarBase CreateProgressBar()
        {
            updateTimer.Start();
            return base.CreateProgressBar();
        }

        private void UpdateTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (ProgressBar.MaxTicks - ProgressBar.CurrentTick < progressStep)
            {
                Tick(0);
            }
            else
            {
                TickIncrement(progressStep);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            updateTimer.Elapsed -= UpdateTimerOnElapsed;
            updateTimer.Dispose();
        }
    }
}
