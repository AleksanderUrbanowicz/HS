
using UI;

namespace BaseLibrary.Interfaces
{
    public interface IUIModifier
    {
        void Modify(IPlugginableUI plugginableUI, IPluggableUI pluggableUI, PluggableUIData themeData);
    }
}