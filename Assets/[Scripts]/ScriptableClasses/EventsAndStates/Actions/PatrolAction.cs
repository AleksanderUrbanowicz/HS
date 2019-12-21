using UnityEngine;
namespace StateMachine.Actions
{

    [CreateAssetMenu(fileName = "Action_Patrol", menuName = "States/Actions/Characters/Patrol Action")]
    public class PatrolAction : EmployeeAction
    {
        public override void Act(StateControllerMBBase controller)
        {
            EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;

            //Debug.Log("PatrolAction");
            Patrol(_controller);
        }

        private void Patrol(EmployeeStateControllerMB controller)
        {

            controller.NavMeshAgent.destination = controller.WayPointList[controller.nextWayPoint].position;
            controller.NavMeshAgent.isStopped = false;

            if (controller.NavMeshAgent.remainingDistance <= controller.NavMeshAgent.stoppingDistance && !controller.NavMeshAgent.pathPending)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.WayPointList.Count;
                controller.NavMeshAgent.destination = controller.WayPointList[controller.nextWayPoint].position;
            }
        }

    }
}