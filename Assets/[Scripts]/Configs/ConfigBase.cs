﻿using System;
using System.Collections.Generic;
using UnityEngine;
namespace EditorTools
{
    public class ConfigBase : ScriptableObject
    {
        [NonSerialized] public string Key;
        public List<string> allSelectorParameters = new List<string>();
        public List<ParamsList> selectorParameters = new List<ParamsList>();
    }
}
