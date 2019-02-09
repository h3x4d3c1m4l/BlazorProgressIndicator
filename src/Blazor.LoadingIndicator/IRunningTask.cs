using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.LoadingIndicator
{
    public interface IRunningTask : IDisposable
    {
        double? Progress { get; set; }

        string Maintext { get; set; }

        string Subtext { get; set; }
    }
}
