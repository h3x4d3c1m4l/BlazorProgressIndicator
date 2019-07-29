using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.LoadingIndicator
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
