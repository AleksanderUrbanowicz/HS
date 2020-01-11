using System;

namespace Data
{
    public enum ObjectOrientation
    {
        NONE,
        FLOOR,
        WALL,
        CEILING

    }



    public enum ButtonType
    {
        DEFAULT,
        CONFIRM,
        WARNING,
        ALERT

    }




    public enum PanelType
    {
        DEFAULT,
        LIST,
        POPUP

    }

    [Flags]
    public enum EditorListOption
    {
        None = 0,
        ListSize = 1,
        ListLabel = 2,
        ElementLabels = 4,
        Default = ListSize | ListLabel | ElementLabels,
        NoElementLabels = ListSize | ListLabel
    }

    [Serializable]
    public class EditorColors
    {



    }
    public enum ColorPurpose
    {
        MainColor = 0,
        ConfirmColor = 1,
        WarningColor = 2,
        NegateColor = 3,
        BackgroundColorLight = 4,
        FontColorDark = 5
    }
}
