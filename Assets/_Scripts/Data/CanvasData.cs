using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "CanvasData_", menuName = "UI/Canvas Data")]

    public class CanvasData : ScriptableObject
    {
        public RenderMode renderMode;
        public bool pixelPerfect;
        public string UICameraTag;
    }
}