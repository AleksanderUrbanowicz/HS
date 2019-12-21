using EditorTools;
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

        protected override void OnThemeDraw()
        {
            base.OnThemeDraw();
            image = GetComponent<Image>();

            button = GetComponent<Button>();
            button.targetGraphic = image;
            image.sprite = themeData.defaultButtonSprite;
            image.type = themeData.buttonImageType;
            image.color = themeData.defaultColor;

            if (themeData.iconSize != Vector2.zero)
            {
                iconImage.rectTransform.sizeDelta = themeData.iconSize;

            }

            if (iconImage != null)
            {
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