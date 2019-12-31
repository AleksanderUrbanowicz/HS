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
        public int size;
        public Image iconImage;
        public ButtonType buttonType;
        public Text text;

        public Image[] images;
        protected override void OnThemeDraw()
        {
            base.OnThemeDraw();

            button = GetComponent<Button>();
            if (images == null)
            {

                images = GetComponentsInChildren<Image>();

            }
            if (images.Length==1)
            {
                image = images[0];
                GameObject go = new GameObject();
                go.transform.parent = gameObject.transform;
                go.name = "icon";
                iconImage = go.AddComponent<Image>();

            }
            image = images[0];
            SetButtonImages();

            if (text == null)
            {

                text = GetComponentInChildren<Text>();
                if (!text)
                {
                    GameObject go = new GameObject();
                    go.transform.parent = gameObject.transform;
                    go.name = "text";

                    text = go.AddComponent<Text>();

                }
            }
          
                SetButtonSize();
          
        }


        private void SetButtonImages()
        {
      
         
            button.targetGraphic = image;
            image.type = themeData.buttonImageType;

            switch (buttonType)
            {
                case ButtonType.CONFIRM:
                    {

                        iconImage.sprite = themeData.buttonsSpriteData.positiveSprite;

                        image.color = themeData.buttonsColorData.positiveColor;
                        break;
                    }
                case ButtonType.WARNING:
                    {

                        iconImage.sprite = themeData.buttonsSpriteData.neutralSprite;
                        image.color = themeData.buttonsColorData.neutralColor;
                        break;
                    }

                case ButtonType.ALERT:
                    {

                        //iconImage.enabled = false;
                        image.color = themeData.buttonsColorData.negativeColor;
                        iconImage.sprite = themeData.buttonsSpriteData.negativeSprite;

                        break;
                    }



            }

        }
        private void SetButtonSize()
        {
            if (size == 0)
            {
                size = (int)(themeData.defaultSize.x + themeData.defaultSize.y) / 10;

            }
            text.fontSize = size;
            text.color = themeData.buttonsColorData.fontColor;
            controlRect.sizeDelta = themeData.defaultButtonSize * relativeSize;
            text.rectTransform.sizeDelta = themeData.defaultButtonSize  * relativeSize * 0.6f; ;
            iconImage.rectTransform.sizeDelta = themeData.defaultIconSize  *relativeSize ;

            // text.rectTransform.sizeDelta = themeData.smallControlSize * new Vector2(themeData.buttonTextRect.width, themeData.buttonTextRect.height) * relativeSize;

            /*
            switch (controlSize)
            {
                case ControlSize.DEFAULT:
                    {


                        break;
                    }
                case ControlSize.SMALL:
                    {
                        text.fontSize = themeData.smallFontSize;
                        // text.rectTransform.sizeDelta = themeData.smallControlSize * themeData.buttonTextRelativeSize*relativeSize;

                        // text.rectTransform.sizeDelta = themeData.smallControlSize * new Vector2(themeData.buttonTextRect.width, themeData.buttonTextRect.height) * relativeSize;
                        //text.rectTransform.anchoredPosition = Vector2.zero;
                        text.rectTransform.localPosition = Vector2.zero;
                        text.rectTransform.anchorMin = new Vector2(themeData.buttonTextRect.x, themeData.buttonTextRect.y);
                        text.rectTransform.anchorMax = new Vector2(themeData.buttonTextRect.x + themeData.buttonTextRect.width, themeData.buttonTextRect.y + themeData.buttonTextRect.height);
                        //  text.rectTransform.localPosition = Vector2.zero;
                        iconImage.rectTransform.sizeDelta = themeData.smallControlSize * new Vector2(themeData.buttonIconRect.width, themeData.buttonIconRect.height) * relativeSize;
                        iconImage.rectTransform.anchorMin = new Vector2(themeData.buttonIconRect.x, themeData.buttonIconRect.y);
                        iconImage.rectTransform.anchorMax = new Vector2(themeData.buttonIconRect.x + themeData.buttonIconRect.width, themeData.buttonIconRect.y + themeData.buttonIconRect.height);

                        break;
                    }
                case ControlSize.MEDIUM:
                    {

                        text.fontSize = themeData.mediumFontSize;
                        //text.rectTransform.sizeDelta = themeData.mediumControlSize * themeData.buttonTextRelativeSize * relativeSize;
                        text.rectTransform.sizeDelta = themeData.mediumControlSize * new Vector2(themeData.buttonTextRect.width, themeData.buttonTextRect.height) * relativeSize;
                        //  text.rectTransform.anchoredPosition = new Vector2(themeData.buttonTextRect.x, themeData.buttonTextRect.y) * text.rectTransform.sizeDelta;

                        iconImage.rectTransform.sizeDelta = themeData.mediumControlSize * new Vector2(themeData.buttonIconRect.width, themeData.buttonIconRect.height) * relativeSize;

                        break;
                    }
                case ControlSize.LARGE:
                    {
                        text.rectTransform.sizeDelta = themeData.largeControlSize * new Vector2(themeData.buttonTextRect.width, themeData.buttonTextRect.height) * relativeSize;
                        //  text.rectTransform.localPosition = themeData.smallControlSize * new Vector2( themeData.buttonTextRect.x, themeData.buttonTextRect.y) * relativeSize;

                        iconImage.rectTransform.sizeDelta = themeData.largeControlSize * new Vector2(themeData.buttonIconRect.width, themeData.buttonIconRect.height) * relativeSize;

                        text.fontSize = themeData.largeFontSize;
                        break;
                    }
                case ControlSize.HUGE:
                    {
                        text.rectTransform.sizeDelta = themeData.hugeControlSize * new Vector2(themeData.buttonTextRect.width, themeData.buttonTextRect.height) * relativeSize;
                        iconImage.rectTransform.sizeDelta = themeData.hugeControlSize * new Vector2(themeData.buttonIconRect.width, themeData.buttonIconRect.height) * relativeSize;

                        text.fontSize = themeData.hugeFontSize;

                        break;
                    }


            }
            */

        }
    }
}