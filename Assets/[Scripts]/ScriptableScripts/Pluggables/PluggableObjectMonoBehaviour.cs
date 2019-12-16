using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    public class PluggableObjectMonoBehaviour : PluggableMonoBehaviour
    {

        public BuildObjectData buildObjectData;
        public void Init(BuildObjectData _buildObjectData)
        {
            buildObjectData = _buildObjectData;
             totalParams = _buildObjectData.pluggableParams;

            

        }
    }
}