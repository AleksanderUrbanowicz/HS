using UnityEngine;
namespace StateMachine
{
    [CreateAssetMenu(fileName = "Decision_Timed", menuName = "States/Decisions/Timed Decision")]

    public class TimedDecision : Decision
    {
        public float time;

        public override bool Decide(StateControllerMBBase controller)
        {
            bool countdownElapsed = controller.CheckIfCountDownElapsed(time / (controller.interval + 1));
            return countdownElapsed;
        }
    }
}