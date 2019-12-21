using Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class ThemeUIPanel : ThemeUI
    {
        Image image;


        public Image iconImage;
        public PanelType panelType;

        protected override void OnThemeDraw()
        {
            base.OnThemeDraw();
            image = GetComponent<Image>();



            switch (panelType)
            {
                case PanelType.DEFAULT:
                    {


                        image.color = themeData.confirmationColor;
                        break;
                    }
                case PanelType.LIST:
                    {


                        image.color = themeData.warningColor;
                        break;
                    }
                case PanelType.POPUP:
                    {


                        image.color = themeData.alertColor;
                        break;
                    }




            }
        }
    }
}