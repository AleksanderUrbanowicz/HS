using Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class ThemeUIPanel : ThemeUI
    {
        Image image;


        // public Image iconImage;
        public PanelType panelType;

        protected override void OnThemeDraw()
        {
            base.OnThemeDraw();
            image = GetComponent<Image>();



            switch (panelType)
            {
                case PanelType.DEFAULT:
                    {


                        image.color = ThemeData.sliderData.colorData.NegativeColor;
                        break;
                    }
                case PanelType.LIST:
                    {


                        image.color = ThemeData.sliderData.colorData.PositiveColor;
                        break;
                    }





            }
        }
    }
}