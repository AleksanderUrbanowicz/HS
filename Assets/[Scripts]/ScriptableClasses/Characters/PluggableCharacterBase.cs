using EditorTools;
using Interfaces;
using UnityEngine;

namespace Characters
{
    // [CreateAssetMenu(fileName = "CharacterData", menuName = "Characters/Character Data")]

    public class PluggableCharacterBase : ScriptableObject, ISpawnable
    {
        public string id, displayName;
        public GameObject prefab;
        public PluggableParams accumulatedParams;
        public PluggableParams individualParams;
        public PluggableCharacterRole characterRole;

        public GameObject GetPrefab()
        {
            return prefab;
        }

        public string GetID()
        {
            return id;
        }
    }

}

