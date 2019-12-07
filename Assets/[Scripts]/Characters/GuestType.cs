using EditorTools;
using ScriptableSystems;
using System;
using System.Collections.Generic;

namespace Characters
{
    [Serializable]
    public class GuestType
    {
        public string id;
        [ConfigSelector(paramsSetKey = "GuestParams")]
        public List<string> requirements = new List<string>();
    }
}