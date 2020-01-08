using BaseLibrary.StateMachine;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "Decision_Employee_InteractFinished", menuName = "States/Decisions/Characters/Interact Finished Decision")]

    public class InteractFinishedEmployeeDecision : EmployeeDecision
    {
        public override bool Decide(StateControllerMBBase controller)
        {
            EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;
            foreach (Transform t in _controller.interactablePoints)
            {
                if (t.transform.position == _controller.Target.position)
                {

                    // controller.interactablePoints.Remove(controller.target);
                    return true;
                }

            }

            return false;

        }
    }
}