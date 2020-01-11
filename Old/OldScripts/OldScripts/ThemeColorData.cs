using System;
using UnityEngine;

namespace UI.Data
{
    [Serializable]
    public class ThemeColorData
    {
        public Color defaultColor;
        public Color positiveColor;
        public Color negativeColor;
        public Color neutralColor;
        public Color infoColor;
        public Color fontColor;
        public Color backgroundColor;

        public ColorModifier colorModifier;
        public bool applyModifier;
        public Color ColorModifier { get { return colorModifier.modifier; } set => colorModifier.modifier = value; }

        public Color DefaultColor { get { return applyModifier == true ? colorModifier.ApplyModifier(defaultColor) : defaultColor; } set => defaultColor = value; }
        public Color PositiveColor { get { return applyModifier == true ? colorModifier.ApplyModifier(positiveColor) : positiveColor; } set => positiveColor = value; }
        public Color NegativeColor { get { return applyModifier == true ? colorModifier.ApplyModifier(negativeColor) : negativeColor; } set => negativeColor = value; }
        public Color NeutralColor { get { return applyModifier == true ? colorModifier.ApplyModifier(neutralColor) : neutralColor; } set => neutralColor = value; }
        public Color InfoColor { get { return applyModifier == true ? colorModifier.ApplyModifier(infoColor) : infoColor; } set => infoColor = value; }
        public Color FontColor { get { return applyModifier == true ? colorModifier.ApplyModifier(fontColor) : fontColor; } set => fontColor = value; }
        public Color BackgroundColor { get { return applyModifier == true ? colorModifier.ApplyModifier(backgroundColor) : backgroundColor; } set => backgroundColor = value; }
    }
}