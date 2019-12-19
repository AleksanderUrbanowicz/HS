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
        public EmployeeStateControllerMB stateController;
        public PluggableCharacterData pluggableCharacterData;
        public ScriptableEventListener scriptableEventListener;
        public bool setupAI;
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
                stateController = gameObject.GetComponent<EmployeeStateControllerMB>();
                if (stateController == null)
                {
                    stateController = gameObject.AddComponent<EmployeeStateControllerMB>();

                }

                stateController.wayPointList = ScriptableSystemManager.Instance.patrolWaypoints;
                stateController.interactablePoints = ScriptableSystemManager.Instance.interactablePoints;
            }
            stateController.currentState = pluggableCharacterData.characterRole.startState;
            if (AIStartEvent != null)
            {
                scriptableEventListener = GetComponent<ScriptableEventListener>();
                if (scriptableEventListener != null)
                {
                    scriptableEventListener.Event = AIStartEvent;
                    scriptableEventListener.Event.RegisterListener(scriptableEventListener);
                }
            }
            else
            {
                SetupAI();

            }
           
        }





        public void SetupAI()
        {
            stateController.Setup(setupAI);

        }

        private void Update()
        {

        }
    }

}