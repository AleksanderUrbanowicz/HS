using Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class ThemeUIButton : ThemeUI
    {
        Image image;
        Button button;

        public Image iconImage;
        public ButtonType buttonType;
        public Text text;

        public Image[] images;
        protected override void OnThemeDraw()
        {
            base.OnThemeDraw();
            if(images==null)
            {

                images = GetComponentsInChildren<Image>();

            }
            //image = GetComponent<Image>();
            image = images[0];
            button = GetComponent<Button>();
            text = GetComponentInChildren<Text>();
            button.targetGraphic = image;
            iconImage =images[1];
            image.sprite = themeData.defaultButtonSprite;
            image.type = themeData.buttonImageType;
            image.color = themeData.defaultColor;

          

            if (iconImage != null)
            {
                if (themeData.iconSize != Vector2.zero)
                {
                    iconImage.rectTransform.sizeDelta = themeData.iconSize;
                    text.rectTransform.sizeDelta = themeData.iconSize;

                    // image.rectTransform.sizeDelta = themeData.iconSize*1.25f;

                }

                switch (buttonType)
                {
                    case ButtonType.CONFIRM:
                        {

                            iconImage.sprite = themeData.confirmationIcon;
                            image.color = themeData.confirmationColor;
                            break;
                        }
                    case ButtonType.WARNING:
                        {

                            iconImage.sprite = themeData.warningIcon;
                            image.color = themeData.warningColor;
                            break;
                        }
                    case ButtonType.ALERT:
                        {

                            iconImage.sprite = themeData.alertIcon;
                            image.color = themeData.alertColor;
                            break;
                        }
                    case ButtonType.DEFAULT:
                        {

                            iconImage.enabled = false;
                            image.color = themeData.defaultColor;
                            break;
                        }

                }

                

            }
        }

    }
}