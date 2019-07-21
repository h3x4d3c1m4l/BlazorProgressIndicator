using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.LoadingIndicator
{
    public interface ITaskProgress : IDisposable
    {
        double? ProgressValue { get; set; }

        double? ProgressMax { get; set; }

        string Maintext { get; set; }

        string Subtext { get; set; }
    }
}
