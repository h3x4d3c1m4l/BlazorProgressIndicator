using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.LoadingIndicator
{
    public abstract class LoadingIndicatorTemplateBase : ComponentBase
    {
        public ITaskStatus CurrentTask { protected get; set; }

        public Task CallStateHasChanged() => InvokeAsync(StateHasChanged);
    }
}
