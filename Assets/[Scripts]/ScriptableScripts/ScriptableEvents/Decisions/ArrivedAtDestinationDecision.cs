using UnityEngine;

[CreateAssetMenu(fileName = "Decision_ArrivedAtDestination", menuName = "States/Decisions/Arrived At Destination Decision")]

public class ArrivedAtDestinationDecision : Decision
{
    public override bool Decide(StateControllerMB controller)
    {
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            return true;
        }
        return false;
    }

}
