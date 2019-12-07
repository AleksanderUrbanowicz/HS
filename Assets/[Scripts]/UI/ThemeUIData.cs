using UnityEngine;
using UnityEngine.UI;


namespace ScriptableSystems
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

        public Sprite defaultButtonSprite;
        public Sprite confirmationIcon;
        public Sprite alertIcon;
        public Sprite warningIcon;
        public Image.Type buttonImageType;

        public Vector2 iconSize;
    }
}