using UnityEngine;

namespace Assets._Scripts.UI.Data
{
    public interface IColorModifier
    {
        Color ApplyModifier(Color color);
    }
}