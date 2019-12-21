using EditorTools;
using ScriptableData;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class PluggableObjectMonoBehaviour : PluggableMonoBehaviour
    {

        public BuildObjectData buildObjectData;
        public List<DynamicParameter> currentConditions;
        public void Init(BuildObjectData _buildObjectData, List<DynamicParameter> _currentConditions = null)
        {

            // Debug.LogError("PluggableObjectMonoBehaviour.Init");
            buildObjectData = _buildObjectData;
            totalParams = _buildObjectData.pluggableDynamicParams.ToPluggableParams();
            if (_currentConditions != null)
            {
                currentConditions = new List<DynamicParameter>(_currentConditions);

            }




        }


    }
}