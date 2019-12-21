using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    [RequireComponent(typeof(Image))]
    public class ThemeUIPanel : ThemeUI
    {
        Image image;


        public Image iconImage;
        public Managers.PanelType panelType;

        protected override void OnThemeDraw()
        {
            base.OnThemeDraw();
            image = GetComponent<Image>();



            switch (panelType)
            {
                case Managers.PanelType.DEFAULT:
                    {


                        image.color = themeData.confirmationColor;
                        break;
                    }
                case Managers.PanelType.LIST:
                    {


                        image.color = themeData.warningColor;
                        break;
                    }
                case Managers.PanelType.POPUP:
                    {


                        image.color = themeData.alertColor;
                        break;
                    }




            }
        }
    }
}