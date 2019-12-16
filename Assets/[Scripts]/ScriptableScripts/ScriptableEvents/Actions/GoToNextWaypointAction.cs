using UnityEngine;
[CreateAssetMenu(fileName = "Action_GoToNextWaypoint", menuName = "States/Actions/Go To Next Waypoint Action")]

public class GoToNextWaypointAction : Action
{

    public override void Act(StateControllerMB controller)
    {


        if (controller.wayPointList != null && controller.wayPointList.Count > 0)
        {
            GoToTarget(controller);


        }
        else
        {
            Debug.LogError("GoToAction: controller.target is null");
        }
    }

    private void GoToTarget(StateControllerMB controller)
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
