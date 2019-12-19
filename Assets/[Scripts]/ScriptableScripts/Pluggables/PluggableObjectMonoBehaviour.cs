using EditorTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    public class PluggableObjectMonoBehaviour : PluggableMonoBehaviour
    {
        
        public BuildObjectData buildObjectData;
        public List<ParameterBase> currentConditions;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_buildObjectData"></param>
        /// <param name="_currentConditions">passive interactable values for objects Loaded,for new build objects _currentConditions=null => currentConditions=startingConditions</param>
        public void Init(BuildObjectData _buildObjectData, List<ParameterBase> _currentConditions=null)  
        {

            Debug.LogError("PluggableObjectMonoBehaviour.Init");
            buildObjectData = _buildObjectData;
             totalParams = _buildObjectData.pluggableParams;
            if (_currentConditions != null)
            {
                currentConditions = new List<ParameterBase>(_currentConditions);

            }
            else
            {
                currentConditions = new List<ParameterBase>();
                foreach (ParameterBase parameterBase in totalParams.GetInteractableParams().passiveParameters)
                {

                    currentConditions.Add(new ParameterBase(parameterBase.id, parameterBase.value));
                }
            }
            
            

        }

      
    }
}