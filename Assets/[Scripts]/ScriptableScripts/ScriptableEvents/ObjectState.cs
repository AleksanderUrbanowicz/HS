using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectState : State
{
   // new public ObjectAction[] actions;
   // new public Transition[] transitions;
    /*
    private void DoActions(BuildObjectStateControllerMB controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(BuildObjectStateControllerMB controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = (transitions[i].decision as ObjectDecision).Decide(controller);

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
