using EditorTools;
using ScriptableSystems;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "GuestData", menuName = "Characters/Guest Data")]
    public class GuestData : CharacterDataBase
    {
        [ConfigSelector(paramsSetKey = GlobalConfig.GuestTypeSelectorKey)]

        public string GuestType;
        //additional requirements, besides requirements based on GuestType
        public List<string> requirements = new List<string>(); 
        
        public GuestData()
        {
            characterType = "Guest";
        }

    }
}