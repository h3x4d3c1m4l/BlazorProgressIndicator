using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.LoadingIndicator
{
    public abstract class LoadingIndicatorTemplateBase : ComponentBase
    {
        public ITaskStatus CurrentTask { protected get; set; }

        public void CallStateHasChanged() => StateHasChanged();
    }
}
