using UnityEngine;

namespace Characters
{
    // [CreateAssetMenu(fileName = "CharacterData", menuName = "Characters/Character Data")]

    public class PluggableCharacterBase : ScriptableObject
    {
        public string id, displayName;
        public GameObject prefab;



    }

}

