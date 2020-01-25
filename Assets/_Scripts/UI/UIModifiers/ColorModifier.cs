using BaseLibrary.Interfaces;
using System;
using UnityEngine;

namespace BaseLibrary.UI
{
    [Serializable]
    public class ColorModifier : IColorApplier
    {
        public Color modifier;
        [Range(0.0f, 1.0f)]
        public float t;

        public ColorModifier()
        {
            modifier = Color.white;
            t = 0.5f;
        }

        public ColorModifier(Color modifier, float t)
        {
            this.modifier = modifier;
            this.t = t;
        }

        public Color ApplyModifier(Color color)
        {
            return Color.Lerp(color, modifier, t);
        }

   
    }
}