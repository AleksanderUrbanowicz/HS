using UnityEngine;
using UnityEngine.UI;

namespace ScriptableSystems
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class ThemeUIButton : ThemeUI
    {
        Image image;
        Button button;

        public Image iconImage;
        public ScriptableSystems.ButtonType buttonType;

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
                    case ScriptableSystems.ButtonType.CONFIRM:
                        {

                            iconImage.sprite = themeData.confirmationIcon;
                            image.color = themeData.confirmationColor;
                            break;
                        }
                    case ScriptableSystems.ButtonType.WARNING:
                        {

                            iconImage.sprite = themeData.warningIcon;
                            image.color = themeData.warningColor;
                            break;
                        }
                    case ScriptableSystems.ButtonType.ALERT:
                        {

                            iconImage.sprite = themeData.alertIcon;
                            image.color = themeData.alertColor;
                            break;
                        }
                    case ScriptableSystems.ButtonType.DEFAULT:
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