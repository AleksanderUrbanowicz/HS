using UnityEngine;

[CreateAssetMenu(fileName = "GoToAction", menuName = "States/Actions/Go To Action")]

public class GoToTargetAction : Action
{
    public override void Act(StateControllerMB controller)
    {
        if (controller.target!=null)
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


        controller.navMeshAgent.destination = controller.target.position;
        controller.navMeshAgent.isStopped = false;
    }
}
