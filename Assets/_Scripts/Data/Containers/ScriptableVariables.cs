using UnityEngine;

namespace Assets._Scripts.Data.Containers
{
    [CreateAssetMenu(fileName = "ScriptableFloat", menuName = "Data/Collections/Scriptable Float")]
    public class ScriptableFloat : ScriptableObject
    {
        public float value;
    }

    [CreateAssetMenu(fileName = "ScriptableBool", menuName = "Data/Collections/Scriptable Bool")]
    public class ScriptableBool : ScriptableObject
    {
        public bool value;
    }

    [CreateAssetMenu(fileName = "ScriptableInt", menuName = "Data/Collections/Scriptable Int")]
    public class ScriptableInt : ScriptableObject
    {
        public bool value;
    }
}