using System;


namespace EditorTools
{
    [Flags]
    public enum EditorListOption {
        None = 0,
        ListSize = 1,
        ListLabel = 2,
        ElementLabels = 4,
        Default = ListSize | ListLabel | ElementLabels,
        NoElementLabels = ListSize | ListLabel    }
    
    
    
    
}