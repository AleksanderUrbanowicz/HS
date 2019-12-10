
using EditorTools;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    // [CreateAssetMenu(fileName = "CharacterData", menuName = "Characters/Character Data")]

    public class PluggableCharacterBase : ScriptableObject
    {
        public string id, displayName;
        public GameObject prefab;

        //varies from object to object
        //Textfield editor
        public PluggableParams individualParams;
        public PluggableCharacterRole characterRole;

    

    }

}

