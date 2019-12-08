using EditorTools;
using System;
using System.Collections.Generic;

namespace Characters
{
    [Serializable]
    public class EmployeeType
    {
        public string id;

        [ConfigSelector(paramsSetKey = StringDefines.EmployeeParameterSelectorKey)]
        public List<string> affectedParameters;
    }
}