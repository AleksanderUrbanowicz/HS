using System;
using UnityEngine;

namespace EditorTools
{
    [Serializable]
    public class ParameterBase
    {
        [ConfigSelector(paramsSetKey = StringDefines.AnyParameterSelectorKey)]
        public string id;

        //Initial value/ one-time increment.
        [Range(-100, 100)]
        public float value;
        public ParameterBase()
        {

        }
        public ParameterBase(string _id, float _val)
        {
            id = _id;
            value = _val;

        }
    }
}