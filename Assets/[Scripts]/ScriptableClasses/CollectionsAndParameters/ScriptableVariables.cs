using UnityEngine;

namespace ScriptableData
{
    [CreateAssetMenu(fileName = "ScriptableFloat", menuName = "Collections/Scriptable Float")]
    public class ScriptableFloat : ScriptableObject
    {
        public float value;
    }

    [CreateAssetMenu(fileName = "ScriptableBool", menuName = "Collections/Scriptable Bool")]
    public class ScriptableBool : ScriptableObject
    {
        public bool value;
    }

    [CreateAssetMenu(fileName = "ScriptableInt", menuName = "Collections/Scriptable Int")]
    public class ScriptableInt : ScriptableObject
    {
        public bool value;
    }
}