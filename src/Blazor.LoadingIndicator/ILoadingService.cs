using System;
using System.Threading.Tasks;

namespace Blazor.LoadingIndicator
{
    public interface ILoadingService
    {
        Type DefaultTemplateType { get; set; }
        Task StartTaskAsync(Func<ITaskStatus, Task> action, string context = "", string maintext = null, string subtext = null);
        void SubscribeToTaskProgressChanged(string context, Action<ITaskStatus> action);
        void UnsubscribeFromTaskProgressChanged(string context, Action<ITaskStatus> action);
    }
}