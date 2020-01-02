using UnityEngine;


namespace Assets._Scripts.UI.Data
{
    [CreateAssetMenu(fileName = "ThemeUIData", menuName = "ScriptableSystems/UI System/Theme UI Data")]

    public class ThemeUIData : ScriptableObject
    {
        const float space = 4.0f;

        public string id;
        public ThemeGfxData generalData;
        public ThemeGfxData buttonData;
        public ThemeGfxData sliderData;
        public Color blendColorOverride = Color.white;

        private void OnEnable()
        {
            //  generalData = new ThemeGfxData(defaultSize, generalColorData, generalSpriteData, Image.Type.Simple);
            //  buttonData = new ThemeGfxData(defaultButtonSize, buttonsColorData, buttonsSpriteData,buttonImageType);
            // sliderData  = new ThemeGfxData(defaultSliderSize, sliderColorData, sliderSpriteData, sliderImageType);

        }
    }
}