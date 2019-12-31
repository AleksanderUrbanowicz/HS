using EditorTools;
using Interfaces;
using UnityEngine;

namespace Characters
{
    // [CreateAssetMenu(fileName = "CharacterData", menuName = "Characters/Character Data")]

    public abstract class PluggableCharacterBase : ScriptableObject, ISpawnable
    {
        public string id, displayName;
        public GameObject prefab;
        public PluggableParams accumulatedParams;
        public PluggableParams individualParams;
        public PluggableCharacterRole characterRole;

        GameObject ISpawnable.GetPrefab
        {
            get { return prefab; }
        }

        string ISpawnable.GetID => id;
    }

}

