using System;
using UnityEngine;

namespace EditorTools
{


    [Serializable]
    public class DynamicParameter : ParameterBase
    {
        [Range(0,1)]
        public float changeRate;
        public DynamicParameter()
        {


        }
        public DynamicParameter(string _id, float _val, float _valChange)
        {
            id = _id;
            value = _val;
            changeRate = _valChange;

        }

        public ParameterBase ToParameterBase()
        {
            ParameterBase parameterBase = new ParameterBase(id, value);
            return parameterBase;

        }
    }
}