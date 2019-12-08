using EditorTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorTools
{


    [Serializable]
    public class DynamicParameter : ParameterBase
    {

        public float changeRate;
        public DynamicParameter()
        {
          

        }
        public DynamicParameter(string _id, float _val,float _valChange)
        {
            id = _id;
            value = _val;
            changeRate = _valChange;

        }
    }
}