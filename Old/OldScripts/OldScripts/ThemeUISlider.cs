using UnityEngine;
using UnityEngine.UI;

namespace UI.MonoBehaviours
{
    [RequireComponent(typeof(Image))]
    //[RequireComponent(typeof(Slider))]
    public class ThemeUISlider : PluggableUIElement
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
            if (labels == null)
            {

                labels = GetComponentsInChildren<Text>();
            }
            backgroundPanelImage = gameObject.GetComponent<Image>();
            slider = GetComponentInChildren<Slider>();
            backgroundImage = slider.gameObject.GetComponent<Image>();
            fillImage = slider.fillRect.gameObject.GetComponent<Image>();
            handleImage = slider.handleRect.gameObject.GetComponent<Image>();

            fillImage.type = ThemeData.sliderData.imageType;
            fillImage.sprite = ThemeData.sliderData.spriteData.frontSprite;
            fillImage.color = ThemeData.sliderData.colorData.PositiveColor;

            backgroundImage.type = ThemeData.sliderData.imageType;
            backgroundImage.color = ThemeData.sliderData.colorData.NegativeColor;
            backgroundImage.sprite = ThemeData.sliderData.spriteData.backgroundSprite;

            handleImage.sprite = ThemeData.sliderData.spriteData.detailSprite;
            handleImage.color = ThemeData.sliderData.colorData.NeutralColor;

            backgroundPanelImage.sprite = ThemeData.sliderData.spriteData.backgroundSprite;
            backgroundPanelImage.color = ThemeData.sliderData.colorData.BackgroundColor;

            foreach (Text t in labels)
            {

                t.color = ThemeData.sliderData.colorData.FontColor;
            }
        }
    }
}