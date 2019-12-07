using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorTools
{
    [Serializable]
    public class ParameterBase
    {
        public string id;
        //Initial value/ one-time increment.
        public float value;
    }
}