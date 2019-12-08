using EditorTools;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Characters/Character Data")]

    public  class CharacterDataBase : ScriptableObject
    {
        public string id;
        //[ConfigSelector(paramsSetKey = StringDefines.CharacterTypeSelectorKey)]
        protected  string characterType;
        //Name + surname ?
        public string displayName;
        public GameObject prefab;

        public List<ParameterBase> staticParameters;
        public List<DynamicParameter> dynamicParameters;


        public CharacterDataBase()
        {

            characterType = "CharacterDataBase";
        }
    }
}