using System;

namespace H3x.BlazorProgressIndicator
{
    public class IndicatorOptions
    {
        public Type IndicatorTemplate { get; set; } = typeof(DefaultTemplate);

        public IndicatorChildContentHideModes ChildContentHideMode { get; set; } = IndicatorChildContentHideModes.CssDisplayNone;
    }

    public enum IndicatorChildContentHideModes
    {
        CssDisplayNone = 0,
        CssVisibilityHidden = 1,
        RemoveFromTree = 2
    }
}
