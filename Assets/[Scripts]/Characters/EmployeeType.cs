using EditorTools;
using System;
using System.Collections.Generic;

namespace Characters
{
    [Serializable]
    public class EmployeeType
    {
        public string id;

        [ConfigSelector(paramsSetKey =GlobalConfig.EmployeeParameterSelectorKey)]
        public List<string> affectedParameters;
    }
}