using System;
using System.Threading.Tasks;

namespace H3x.BlazorProgressIndicator
{
    public interface IIndicatorService
    {
        Task StartTaskAsync(Func<ITaskStatus, Task> action, string context = "", string maintext = null, string subtext = null);

        void SubscribeToTaskProgressChanged(string context, Func<ITaskStatus, Task> action);

        void UnsubscribeFromTaskProgressChanged(string context, Func<ITaskStatus, Task> action);

        IndicatorOptions Options { get; }
    }
}