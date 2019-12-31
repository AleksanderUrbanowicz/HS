using StateMachine.Actions;
using UnityEngine;
namespace StateMachine
{
    [CreateAssetMenu(fileName = "State", menuName = "States/State")]
    public class State : ScriptableObject
    {

        public Action[] actions;
        public Transition[] transitions;
        public Color sceneGizmoColor = Color.grey;

        public void UpdateState(StateControllerMBBase controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }

        private void DoActions(StateControllerMBBase controller)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Act(controller);
            }
        }

        private void CheckTransitions(StateControllerMBBase controller)
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i].decision == null)
                {
                    Debug.LogError(this.name + ".transitions[" + i + "].decision is null");
                    continue;
                }
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
    }
}