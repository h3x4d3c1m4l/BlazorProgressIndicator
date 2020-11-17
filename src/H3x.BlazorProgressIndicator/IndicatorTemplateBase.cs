using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace H3x.BlazorProgressIndicator
{
    public abstract class IndicatorTemplateBase : ComponentBase
    {
        [Parameter]
        public ITaskStatus CurrentTask { protected get; set; }

        public Task CallStateHasChanged() => InvokeAsync(StateHasChanged);
    }
}
