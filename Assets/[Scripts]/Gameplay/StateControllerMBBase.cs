using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControllerMBBase : MonoBehaviour
{
    public float stateTimeElapsed;
    public State currentState;
    public State remainState;
    public bool isActive;
    public int interval = 10;
    private int counter = 0;

    public void Setup(bool _isActive)
    {

        isActive = _isActive;



    }

    void Update()
    {

        if(counter<interval)
        {
            Debug.Log(counter);
            counter++;
           
            return;
        }
        else
        {
            counter = 0;

        }
        if (!isActive)
            return;

        Debug.Log("UpdateState");
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
