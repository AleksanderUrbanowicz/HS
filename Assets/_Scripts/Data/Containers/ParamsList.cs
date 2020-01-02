using Assets._Scripts.Data.Definitions;
using Assets._Scripts.EditorUtilities;
using System;
using System.Collections.Generic;

namespace Assets._Scripts.Data.Containers
{
    [Serializable]
    public class ParamsList
    {
        public string id;
        [ConfigSelectorAttribute(ParamsSetKey = StringDefines.AnyParameterSelectorKey)]
        public List<string> parameters;


        public ParamsList(string _id, List<string> _parameters)
        {

            id = _id;
            parameters = _parameters;

        }

    }
}
