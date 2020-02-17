using System;
using System.Collections.Generic;
using System.Text;

namespace H3x.BlazorProgressIndicator
{
    public class ProgressIndicatorSettings
    {
        public Type IndicatorTemplate { get; set; } = typeof(DefaultTemplate);
    }
}
