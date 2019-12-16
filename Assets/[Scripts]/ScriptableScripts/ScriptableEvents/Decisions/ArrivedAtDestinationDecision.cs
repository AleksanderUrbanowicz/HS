using UnityEngine;

[CreateAssetMenu(fileName = "Decision_ArrivedAtDestination", menuName = "States/Decisions/Arrived At Destination Decision")]

public class ArrivedAtDestinationDecision : Decision
{
    public float distance = -1;

    public override bool Decide(StateControllerMB controller)
    {
        if(distance==-1)
        {
            distance = controller.navMeshAgent.stoppingDistance;

        }
        //if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        if (controller.navMeshAgent.remainingDistance <= distance && !controller.navMeshAgent.pathPending)

        {
            return true;
        }
        return false;
    }

}
