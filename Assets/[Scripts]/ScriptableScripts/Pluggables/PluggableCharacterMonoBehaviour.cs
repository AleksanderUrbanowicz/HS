using ScriptableSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Characters
{
    [RequireComponent(typeof(NavMeshAgent))]
    //  [RequireComponent(typeof(StateControllerMB))]
    public class PluggableCharacterMonoBehaviour : PluggableMonoBehaviour, IInteractable
    {

        public List<Transform> interactablePointList;
        public StateControllerMB stateController;
        public PluggableCharacterData pluggableCharacterData;
        public bool setupUI;
        public ScriptableEvent AIStartEvent;
        public NavMeshAgent navMeshAgent;
        public void Init(PluggableCharacterData _pluggableCharacterData)
        {
            pluggableCharacterData = _pluggableCharacterData;
            // totalParams = _pluggableCharacterData.accumulatedParams;
            // totalParams = (_pluggableCharacterData as IPluggableParameters).GetAccumulatedParameters();

            InitParams();
            InitNavigation();

        }
        public void InitParams()
        {
            totalParams = (pluggableCharacterData as IPluggableParameters).GetAccumulatedParameters();

            //  GetMatchingParams();
        }


        public void InitNavigation()
        {
            if (navMeshAgent == null)
            {
                navMeshAgent = GetComponent<NavMeshAgent>();

            }
            if (stateController == null)
            {
                stateController = gameObject.GetComponent<StateControllerMB>();
                if (stateController == null)
                {
                    stateController = gameObject.AddComponent<StateControllerMB>();

                }

                stateController.wayPointList = ScriptableSystemManager.Instance.patrolWaypoints;
                stateController.interactablePoints = ScriptableSystemManager.Instance.interactablePoints;
            }
            stateController.currentState = pluggableCharacterData.characterRole.startState;



            stateController.SetupAI(setupUI);
        }





        public void SetupAI()
        {
            stateController.SetupAI(setupUI);

        }

        private void Update()
        {

        }
    }

}