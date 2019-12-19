using UnityEngine;
[CreateAssetMenu(fileName = "Action_GoToNextWaypoint", menuName = "States/Actions/Characters/Go To Next Waypoint Action")]

public class GoToNextWaypointAction : EmployeeAction
{

    public override void Act(StateControllerMBBase controller)
    {

        EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;

        if (_controller.wayPointList != null && _controller.wayPointList.Count > 0)
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

        controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
        controller.navMeshAgent.isStopped = false;

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
        //controller.navMeshAgent.destination = controller.target.position;
        //controller.navMeshAgent.isStopped = false;
    }
}
