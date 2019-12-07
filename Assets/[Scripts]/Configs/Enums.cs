namespace ScriptableSystems
{
    public enum ObjectOrientation
    {
        NONE,
        FLOOR,
        WALL,
        CEILING

    }

    public enum ObjectRotation
    {
        NONE,
        CONTINOUS,
        DISCRETE90

    }
    public enum ScriptableEventType
    {
        INIT,
        DEINIT,
        START,
        STOP

    }

    public enum ScriptableExecuteType
    {
        ON_START,
        ON_REQUEST,
        ON_EVENT,
        ON_UPDATE
    }

    public enum ScriptableSystemType
    {
        SYSTEM,  //Complex system initialized with data from ScriptableObject asset
        EXECUTOR //Single method system, invoking same logic on different input data

    }

    public enum LogLevel
    {
        NONE,
        CRITICAL,
        ALL

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
}
