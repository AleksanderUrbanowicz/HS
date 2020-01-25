using BaseLibrary.Interfaces;
using BaseLibrary.UI;

namespace UI
{
    public interface IColorModifier : IUIModifier
    {
        void Awake();
        void SetColor(PluggableUIData uiData);
    }
}