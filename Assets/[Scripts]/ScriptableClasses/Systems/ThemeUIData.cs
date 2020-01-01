using UnityEngine;
using UnityEngine.UI;


namespace UI
{
    [CreateAssetMenu(fileName = "ThemeUIData", menuName = "ScriptableSystems/UI System/Theme UI Data")]

    public class ThemeUIData : ScriptableObject
    {
        const float space = 4.0f;
        
        public string id;
        public ThemeGfxData generalData;
        public ThemeGfxData buttonData;
        public ThemeGfxData sliderData;
        public Color blendColorOverride=Color.white;/*
        [Space(space)]
        [Header("General and override data")]
        public Vector2 defaultSize;
        public ThemeColorData generalColorData;
        public ThemeSpriteData generalSpriteData;
       // public Color blendColorOverride;
        [Header("Buttons data")]
      
        public Vector2 defaultButtonSize;
        [Range(0.0f, 10.0f)]
        public float defaultButtonAspect;
     
        public Vector2 defaultIconSize;
        public ThemeColorData buttonsColorData;
        public ThemeSpriteData buttonsSpriteData;
        public Image.Type buttonImageType;

        [Header("Bars and Sliders data")]
      
        public Vector2 defaultSliderSize;
        [Range(0.0f, 10.0f)]
        public float defaultSliderAspect;
        public ThemeColorData sliderColorData;
        public ThemeSpriteData sliderSpriteData;
        public Image.Type sliderImageType;
        */

        private void OnEnable()
        {
          //  generalData = new ThemeGfxData(defaultSize, generalColorData, generalSpriteData, Image.Type.Simple);
          //  buttonData = new ThemeGfxData(defaultButtonSize, buttonsColorData, buttonsSpriteData,buttonImageType);
           // sliderData  = new ThemeGfxData(defaultSliderSize, sliderColorData, sliderSpriteData, sliderImageType);

        }
    }
}