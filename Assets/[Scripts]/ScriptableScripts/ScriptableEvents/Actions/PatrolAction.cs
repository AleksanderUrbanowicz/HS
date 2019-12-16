using UnityEngine;


[CreateAssetMenu(fileName = "Action_Patrol", menuName = "States/Actions/Patrol Action")]
public class PatrolAction : Action
{
    public override void Act(StateControllerMB controller)
    {
        //Debug.Log("PatrolAction");
        Patrol(controller);
    }

    private void Patrol(StateControllerMB controller)
    {

        controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
        controller.navMeshAgent.isStopped = false;

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
        }
    }

}
