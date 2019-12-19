using UnityEngine;


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

        controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
        controller.navMeshAgent.isStopped = false;

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
        }
    }

}
