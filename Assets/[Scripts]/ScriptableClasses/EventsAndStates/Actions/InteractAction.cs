using UnityEngine;
namespace StateMachine
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