using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ColorModifier : IColorModifier
{
    public Color modifier;
    [Range(0.0f, 1.0f)]
    public float t;

    public ColorModifier()
    {
        this.modifier = Color.white;
        this.t = 0.5f;
    }

    public ColorModifier(Color modifier, float t)
    {
        this.modifier = modifier;
        this.t = t;
    }

    public Color ApplyModifier( Color color)
    {
        return Color.Lerp(color, modifier, t);
    }
}
