using UnityEngine;
namespace Assets._Scripts.StateMachine
{
    [CreateAssetMenu(fileName = "Action_Employee_GoToAction", menuName = "States/Actions/Characters/Go To Action")]

    public class GoToTargetAction : EmployeeAction
    {
        public override void Act(StateControllerMBBase controller)
        {
            EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;

            if (_controller.Target != null)
            {
                GoToTarget(_controller);

            }
            else
            {
                Debug.LogError("GoToAction: controller.target is null");
            }
        }

        private void GoToTarget(EmployeeStateControllerMB controller)
        {

            controller.NavMeshAgent.destination = controller.Target.position;
            controller.NavMeshAgent.isStopped = false;
        }
    }
}