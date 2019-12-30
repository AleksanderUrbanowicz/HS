using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class ThemeUISlider : ThemeUI
    {
        public Image fillImage;
        protected override void OnThemeDraw()
        {
            base.OnThemeDraw();
            fillImage = GetComponent<Image>();
            fillImage.sprite = themeData.defaultBarSprite;
        }
    }
}