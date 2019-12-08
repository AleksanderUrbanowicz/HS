using EditorTools;
using ScriptableSystems;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "GuestData", menuName = "Characters/Guest Data")]
    public class GuestData : CharacterDataBase
    {
        [ConfigSelector(paramsSetKey = StringDefines.GuestTypeSelectorKey)]

        public string GuestType;
        [RangeAttribute(0.0f, 100.0f)]
        public float generousity;
        [RangeAttribute(0.0f, 100.0f)]
        public float politeness;
        
      
        //[ConfigSelector(paramsSetKey = StringDefines.GuestParameterSelectorKey)]

        //additional requirements, besides requirements based on GuestType
        public List<ParameterBase> requirements = new List<ParameterBase>(); 
        
        public GuestData()
        {
            characterType = "Guest";
        }

    }
}