

using UnityEngine;
namespace StateMachine.Actions
{
    [CreateAssetMenu(fileName = "Action_Employee_GoToNextWaypoint", menuName = "States/Actions/Characters/Go To Next Waypoint Action")]

    public class GoToNextWaypointAction : EmployeeAction
    {

        public override void Act(StateControllerMBBase controller)
        {

            EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;

            if (_controller.WayPointList != null && _controller.WayPointList.Count > 0)
            {
                GoToTarget(_controller);


            }

        }

        private void GoToTarget(EmployeeStateControllerMB controller)
        {

            controller.NavMeshAgent.destination = controller.WayPointList[controller.nextWayPoint].position;
            controller.NavMeshAgent.isStopped = false;

            if (controller.NavMeshAgent.remainingDistance <= controller.NavMeshAgent.stoppingDistance && !controller.NavMeshAgent.pathPending)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.WayPointList.Count;
            }

        }
    }
}