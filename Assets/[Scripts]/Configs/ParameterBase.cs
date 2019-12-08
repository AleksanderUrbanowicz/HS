using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorTools
{
    [Serializable]
    public class ParameterBase
    {
        [ConfigSelector]
        public string id;
       
        //Initial value/ one-time increment.
        [Range(0,100)]
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