using UnityEngine;
namespace StateMachine
{
    [CreateAssetMenu(fileName = "Decision_Employee_StartState", menuName = "States/Decisions/Characters/Start State Decision")]

    public class StartingStateEmployeeDecision : EmployeeDecision
    {


        public override bool Decide(StateControllerMBBase controller)
        {
            EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;
            bool targetIsActive = _controller.Target != null;
            return targetIsActive;
        }

    }
}