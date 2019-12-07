using EditorTools;
using System;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Characters/Character Data")]

    public  class CharacterDataBase : ScriptableObject
    {
        public string id;
        //[CharacterTypeSelector]
        protected  string characterType;
        //Name + surname ?
        public string displayName;
        public GameObject prefab;

        public CharacterDataBase()
        {

            characterType = "Employee";
        }
    }
}