using System;
using System.Collections.Generic;


namespace EditorTools
{
    [Serializable]
    public class ParamsList
    {
        public string id;
        [ConfigSelector(ParamsSetKey = StringDefines.AnyParameterSelectorKey)]
        public List<string> parameters;


        public ParamsList(string _id, List<string> _parameters)
        {

            id = _id;
            parameters = _parameters;

        }

     
    }
}
