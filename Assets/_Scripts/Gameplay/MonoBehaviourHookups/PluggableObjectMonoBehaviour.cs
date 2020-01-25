using Data;
using StateMachine;
using System.Collections.Generic;

namespace Managers
{
    public class PluggableObjectMonoBehaviour : PluggableMonoBehaviour//, IInteractable
    {

        public BuildObjectData buildObjectData;
        public List<DynamicParameter> currentConditions;
        private BuildObjectStateControllerMB stateController;

        public BuildObjectStateControllerMB StateController
        {
            get
            {
                if (stateController == null)
                {
                    stateController = GetComponent<BuildObjectStateControllerMB>();
                    if (stateController == null)
                    {
                        stateController = gameObject.AddComponent<BuildObjectStateControllerMB>();
                    }
                }
                return stateController;
            }
            set { }
        }

        public void Init(BuildObjectData _buildObjectData, List<DynamicParameter> _currentConditions = null)
        {

            // Debug.LogError("PluggableObjectMonoBehaviour.Init");
            buildObjectData = _buildObjectData;
            totalParams = _buildObjectData.pluggableDynamicParams.ToPluggableParams();
          
            StateController.Init(_buildObjectData);
            Setup();
        }
        public void Setup()
        {
            StateController.Setup(true);

        }

    }
}