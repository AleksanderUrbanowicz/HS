using UnityEngine;
using UnityEngine.UI;


namespace UI
{
    [CreateAssetMenu(fileName = "ThemeUIData", menuName = "ScriptableSystems/UI System/Theme UI Data")]

    public class ThemeUIData : ScriptableObject
    {
        const float space = 4.0f;
        public string id;
        [Space(space)]
        [Header("General and override data")]
     //   [Range(1, 400)]
        public Vector2 defaultSize;
        public ThemeColorData generalColorData;
        public ThemeSpriteData generalSpriteData;

        [Header("Buttons data")]
       // [Range(1, 200)]
        public Vector2 defaultButtonSize;
        [Range(0.0f, 10.0f)]
        public float defaultButtonAspect;
      //  [Range(1, 100)]
        public Vector2 defaultIconSize;
        public ThemeColorData buttonsColorData;
        public ThemeSpriteData buttonsSpriteData;
        public Image.Type buttonImageType;

        [Header("Bars and Sliders data")]
      //  [Range(1,250)]
        public Vector2 defaultSliderSize;
        [Range(0.0f, 10.0f)]
        public float defaultSliderAspect;
        public ThemeColorData sliderColorData;
        public ThemeSpriteData sliderSpriteData;
        public Image.Type sliderImageType;
    
    }
}