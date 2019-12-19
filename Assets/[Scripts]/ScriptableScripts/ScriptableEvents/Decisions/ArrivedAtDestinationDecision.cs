using UnityEngine;

[CreateAssetMenu(fileName = "Decision_ArrivedAtDestination", menuName = "States/Decisions/Characters/Arrived At Destination Decision")]

public class ArrivedAtDestinationDecision : EmployeeDecision
{
    public float distance = -1;

    public override bool Decide(StateControllerMBBase controller)
    {
        EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;
        if (distance==-1)
        {
            distance = _controller.navMeshAgent.stoppingDistance;

        }
        //if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        if (_controller.navMeshAgent.remainingDistance <= distance && !_controller.navMeshAgent.pathPending)

        {
            return true;
        }
        return false;
    }

}
