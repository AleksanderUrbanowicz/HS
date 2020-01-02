using Assets._Scripts.Data.Containers;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Assets._Scripts.Data.Configs
{
    public class ConfigBase : ScriptableObject
    {
        [NonSerialized] private string key;
        public List<string> allSelectorParameters = new List<string>();
        public List<ParamsList> selectorParameters = new List<ParamsList>();


        public string Key { get => key; set => key = value; }
    }
}
