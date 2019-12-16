using EditorTools;
using System.Collections.Generic;
using UnityEngine;
namespace Characters
{
    [CreateAssetMenu(fileName = "GuestTypeData", menuName = "Characters/Guest Type Data")]
    public class GuestTypeData : ScriptableObject
    {
        public string id;
        public List<ParameterBase> staticGuestTypeModifiers = new List<ParameterBase>();
        public List<ParameterBase> dynamicGuestTypeModifiers = new List<ParameterBase>();
    }
}