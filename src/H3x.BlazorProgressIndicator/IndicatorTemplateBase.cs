using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace H3x.BlazorProgressIndicator
{
    public abstract class IndicatorTemplateBase : ComponentBase
    {
        public ITaskStatus CurrentTask { protected get; set; }

        public Task CallStateHasChanged() => InvokeAsync(StateHasChanged);
    }
}
