using EditorTools;
using Objects;
using ScriptableData;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class PluggableObjectMonoBehaviour : PluggableMonoBehaviour
    {

        public BuildObjectData buildObjectData;
        public List<DynamicParameter> currentConditions;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_buildObjectData"></param>
        /// <param name="_currentConditions">passive interactable values for objects Loaded,for new build objects _currentConditions=null => currentConditions=startingConditions</param>
        public void Init(BuildObjectData _buildObjectData, List<DynamicParameter> _currentConditions = null)
        {

           // Debug.LogError("PluggableObjectMonoBehaviour.Init");
            buildObjectData = _buildObjectData;
            totalParams = (_buildObjectData.pluggableDynamicParams.ToPluggableParams());
            if (_currentConditions != null)
            {
                currentConditions = new List<DynamicParameter>(_currentConditions);

            }
            else
            {
                currentConditions = new List<DynamicParameter>();
                foreach (DynamicParameter dynamicParameter in _buildObjectData.pluggableDynamicParams.GetInteractableParams().passiveParameters)
                {

                    currentConditions.Add(new DynamicParameter(dynamicParameter));
                }
            }



        }


    }
}