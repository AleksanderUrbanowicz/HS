using Interfaces;
using Managers;
using ScriptableData;
using StateMachine;
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
        private EmployeeStateControllerMB stateController;
        public PluggableCharacterData pluggableCharacterData;
        public ScriptableEventListener scriptableEventListener;
        public bool setupAI;
        public ScriptableEvent AIStartEvent;
        //private NavMeshAgent navMeshAgent;

        public EmployeeStateControllerMB StateController { 
            get {
                if (stateController == null)
                {
                    stateController = GetComponent<EmployeeStateControllerMB>() != null ? GetComponent<EmployeeStateControllerMB>() : gameObject.AddComponent<EmployeeStateControllerMB>();

                }
                return stateController;
            }  }

        public NavMeshAgent NavMeshAgent { get => StateController.NavMeshAgent;  }

        public void Init(PluggableCharacterData _pluggableCharacterData)
        {
            pluggableCharacterData = _pluggableCharacterData;
       

            InitParams();
            InitNavigation();

        }
        public void InitParams()
        {
            totalParams = (pluggableCharacterData as IPluggableParameters).GetAccumulatedParameters();

            
        }
      



        public void InitNavigation()
        {
            
        
            //StateController.WayPointList = ScriptableSystemManager.Instance.patrolWaypoints;
            StateController.interactablePoints = ScriptableSystemManager.Instance.interactablePoints;
            StateController.currentState = pluggableCharacterData.characterRole.startState;
            if (AIStartEvent != null)
            {
                RegisterStartEvent();
            }
            else
            {
                SetupAI();

            }

        }

        private void RegisterStartEvent()
        {

            scriptableEventListener = GetComponent<ScriptableEventListener>();
            if (scriptableEventListener == null)
            {
                scriptableEventListener = gameObject.AddComponent<ScriptableEventListener>();
            }
            
                scriptableEventListener.Event = AIStartEvent;
                scriptableEventListener.Event.RegisterListener(scriptableEventListener);
            

        }

    public void SetupAI()
        {
            StateController.Setup(setupAI);

        }

    }

}