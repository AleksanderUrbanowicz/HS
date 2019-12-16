using EditorTools;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateControllerMB : MonoBehaviour
{
    public State currentState;
    public State remainState;
    public Transform target;
    public NavMeshAgent navMeshAgent;
    public List<Transform> wayPointList;
    public List<Transform> interactablePoints;
    public int nextWayPoint;
    public float stateTimeElapsed;
    public PluggableRuntimeCollection Set;
    private bool aiActive;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (wayPointList == null || wayPointList.Count == 0)
        {
            wayPointList = new List<Transform>();
            wayPointList.Add(new GameObject().transform);
        }
        //SetupAI(true);
    }

    public void SetupAI(bool dynamiAI)
    {

        aiActive = dynamiAI;
        if (aiActive)
        {
            Debug.LogError("SetupAI Active");
        }
        else
        {
            Debug.LogError("SetupAI Active");
        }


    }

    void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }



    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(transform.position, 2);
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}
