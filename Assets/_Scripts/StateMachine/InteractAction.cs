using BaseLibrary.StateMachine;
using UnityEngine;
namespace StateMachine
{
    [CreateAssetMenu(fileName = "Action_Employee_InteractAction", menuName = "States/Actions/Characters/Interact Action")]

    public class InteractAction : EmployeeAction
    {
        public override void Act(StateControllerMBBase controller)
        {
            //EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;

            //  throw new System.NotImplementedException();
        }
    }
}