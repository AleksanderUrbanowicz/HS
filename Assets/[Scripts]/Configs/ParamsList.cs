using EditorTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EditorTools
{
    [Serializable]
    public class ParamsList
    {
        public string id;
        [ConfigSelector(paramsSetKey = GlobalConfig.AnyParameterSelectorKey)]
        public List<string> parameters;


        public ParamsList(string _id, List<string> _parameters)
        {
            id = _id;
            parameters = _parameters;

        }
    }
}
