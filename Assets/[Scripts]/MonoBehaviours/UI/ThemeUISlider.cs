using UnityEngine;
using UnityEngine.UI;

namespace UI
{
     [RequireComponent(typeof(Image))]
    //[RequireComponent(typeof(Slider))]
    public class ThemeUISlider : ThemeUI
    {
        public Slider slider;
        public Image fillImage;
        public Image backgroundImage;
        public Image handleImage;
        public Text[] labels;
        public Image backgroundPanelImage;
        protected override void OnThemeDraw()
        {

            base.OnThemeDraw();
            if(labels==null)
            {

                labels = GetComponentsInChildren<Text>();
            }
             backgroundPanelImage=gameObject.GetComponent<Image>();
            slider = GetComponentInChildren<Slider>();
            backgroundImage = slider.gameObject.GetComponent<Image>();
            fillImage = slider.fillRect.gameObject.GetComponent<Image>();
            handleImage = slider.handleRect.gameObject.GetComponent<Image>();

            fillImage.type = themeData.sliderImageType;
            fillImage.sprite = themeData.sliderSpriteData.frontSprite;
            fillImage.color = themeData.sliderColorData.positiveColor;

            backgroundImage.type = themeData.sliderImageType;
            backgroundImage.color = themeData.sliderColorData.negativeColor;
            backgroundImage.sprite = themeData.sliderSpriteData.backgroundSprite;

            handleImage.sprite = themeData.sliderSpriteData.detailSprite;
            handleImage.color = themeData.sliderColorData.neutralColor;

            backgroundPanelImage.sprite = themeData.generalSpriteData.backgroundSprite;
            backgroundPanelImage.color = themeData.sliderColorData.backgroundColor;

            foreach (Text t in labels)
            {

                t.color = themeData.sliderColorData.fontColor;
            }
        }
    }
}