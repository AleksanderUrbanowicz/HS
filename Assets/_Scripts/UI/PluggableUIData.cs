using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace UI
{
    [CreateAssetMenu(fileName = "Theme_", menuName = "UI/Theme UI Data")]
    public class PluggableUIData : ScriptableObject
    {


        private List<PluggableColor> Colors;
        private List<PluggableSprite> Sprites;
        private List<PluggableFont> Fonts;

        private Color defaultColor;
        private Sprite defaultSprite;
        private Font defaultFont;
      

        public Color GetColor(string id)
        {
            PluggableColor pluggableColor = Colors.FirstOrDefault(x => x.id == id);
            if (pluggableColor == null || pluggableColor.color == null)
            {

                return defaultColor;
            }


            return pluggableColor.color;
        }

        public Sprite GetSprite(string id)
        {
            PluggableSprite pluggableSprite = Sprites.FirstOrDefault(x => x.id == id);
            if (pluggableSprite == null || pluggableSprite.sprite == null)
            {

                return defaultSprite;
            }


            return pluggableSprite.sprite;
        }

        public Font GetFont(string id)
        {
            PluggableFont pluggableFont = Fonts.FirstOrDefault(x => x.id == id);
            if (pluggableFont == null || pluggableFont.font==null)
            {

                return defaultFont;
            }

          
            return pluggableFont.font;
        }
    }
}