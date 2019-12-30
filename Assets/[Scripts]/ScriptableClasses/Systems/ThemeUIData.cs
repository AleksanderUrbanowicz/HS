using UnityEngine;
using UnityEngine.UI;


namespace UI
{
    [CreateAssetMenu(fileName = "ThemeUIData", menuName = "ScriptableSystems/UI System/Theme UI Data")]

    public class ThemeUIData : ScriptableObject
    {
        public string id;
        public Color defaultColor;
        public Color defaultBackgroundColor;
        public Color defaultFontColor;

        public Color confirmationColor;
        public Color warningColor;
        public Color alertColor;

        public float smallControlWidth;
        public float mediumControlWidth;

        public Vector2 smallControlSize;
        public Vector2 mediumControlSize;
        public Vector2 largeControlSize;
        public Vector2 hugeControlSize;

        public Sprite defaultButtonSprite;
        public Sprite defaultBarSprite;

        public Sprite confirmationIcon;
        public Sprite alertIcon;
        public Sprite warningIcon;
        public Image.Type buttonImageType;

        public Vector2 iconSize;
    }
}