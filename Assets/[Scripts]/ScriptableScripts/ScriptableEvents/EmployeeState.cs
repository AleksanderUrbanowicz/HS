using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeState : State
{
   // new public EmployeeAction[] actions;
    /*
    private void DoActions(EmployeeStateControllerMB controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(EmployeeStateControllerMB controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded)
            {
                controller.TransitionToState(transitions[i].trueState);
            }
            else
            {
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }
    */
}
