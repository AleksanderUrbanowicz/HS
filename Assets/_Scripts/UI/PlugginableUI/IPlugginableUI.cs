using BaseLibrary.Interfaces;
using BaseLibrary.UI;

namespace UI
{
    public interface IPlugginableUI
    {

        void PlugData(IPluggableUI pluggableUI, PluggableUIData themeData);

    }
}