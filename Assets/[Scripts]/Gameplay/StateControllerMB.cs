using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControllerMB : MonoBehaviour
{
    public State currentState;
    public State remainState;

    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive;


    void Awake()
    {
        
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
