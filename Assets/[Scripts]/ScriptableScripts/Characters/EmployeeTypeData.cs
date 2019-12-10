
using EditorTools;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "EmployeeTypeData", menuName = "Characters/Employee Type Data")]
    public class EmployeeTypeData : ScriptableObject
    {
        public string id;
        public List<ParameterBase> staticEmployeeTypeModifiers = new List<ParameterBase>();
        public List<ParameterBase> dynamicEmployeeTypeModifiers = new List<ParameterBase>();
    }
}
