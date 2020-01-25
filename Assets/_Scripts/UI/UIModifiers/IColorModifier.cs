using BaseLibrary.Interfaces;


namespace UI
{
    public interface IColorModifier : IUIModifier
    {
        void Awake();
        void SetColor(PluggableUIData uiData);
    }
}