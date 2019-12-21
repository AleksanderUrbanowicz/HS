using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class ThemeUIButton : ThemeUI
    {
        Image image;
        Button button;

        public Image iconImage;
        public Managers.ButtonType buttonType;

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
                    case Managers.ButtonType.CONFIRM:
                        {

                            iconImage.sprite = themeData.confirmationIcon;
                            image.color = themeData.confirmationColor;
                            break;
                        }
                    case Managers.ButtonType.WARNING:
                        {

                            iconImage.sprite = themeData.warningIcon;
                            image.color = themeData.warningColor;
                            break;
                        }
                    case Managers.ButtonType.ALERT:
                        {

                            iconImage.sprite = themeData.alertIcon;
                            image.color = themeData.alertColor;
                            break;
                        }
                    case Managers.ButtonType.DEFAULT:
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