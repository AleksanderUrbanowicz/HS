using UnityEngine;
using UnityEngine.UI;

namespace ScriptableSystems
{
    [RequireComponent(typeof(Image))]
    public class ThemeUIPanel : ThemeUI
    {
        Image image;


        public Image iconImage;
        public ScriptableSystems.PanelType panelType;

        protected override void OnThemeDraw()
        {
            base.OnThemeDraw();
            image = GetComponent<Image>();

            //  image.color = themeData.defaultBackgroundColor;


            switch (panelType)
            {
                case ScriptableSystems.PanelType.DEFAULT:
                    {


                        image.color = themeData.confirmationColor;
                        break;
                    }
                case ScriptableSystems.PanelType.LIST:
                    {


                        image.color = themeData.warningColor;
                        break;
                    }
                case ScriptableSystems.PanelType.POPUP:
                    {


                        image.color = themeData.alertColor;
                        break;
                    }




            }
        }
    }
}