﻿using System;

namespace H3x.BlazorProgressIndicator
{
    public interface ITaskStatus : IDisposable
    {
        double? ProgressValue { get; set; }

        double? ProgressMax { get; set; }

        string Maintext { get; set; }

        string Subtext { get; set; }

        Exception Exception { get; set; }

        void DismissException();
    }
}
