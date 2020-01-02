using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Data
{
    [Serializable]
    public class ThemeGfxData
    {
        public string id;
        public Vector2 defaultSize;
        public Vector2 backgroundSize;
        public Vector2 frontSize;
        public Vector2 detailSize;

        public ThemeColorData colorData;
        public ThemeSpriteData spriteData;
        public Image.Type imageType;
        public ThemeGfxData(Vector2 defaultSize, ThemeColorData colorData, ThemeSpriteData spriteData, Image.Type imageType)
        {
            this.defaultSize = defaultSize;
            this.colorData = colorData;
            this.spriteData = spriteData;
            this.imageType = imageType;
        }
    }

}