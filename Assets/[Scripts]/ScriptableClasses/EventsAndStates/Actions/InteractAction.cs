using UnityEngine;
namespace StateMachine.Actions
{
    [CreateAssetMenu(fileName = "InteractAction", menuName = "States/Actions/Characters/Interact Action")]

    public class InteractAction : EmployeeAction
    {
        public override void Act(StateControllerMBBase controller)
        {
            //EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;

          //  throw new System.NotImplementedException();
        }
    }
}