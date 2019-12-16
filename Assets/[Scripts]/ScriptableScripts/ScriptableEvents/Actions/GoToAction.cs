using UnityEngine;

[CreateAssetMenu(fileName = "GoToAction", menuName = "States/Actions/Go To Action")]

public class GoToAction : Action
{
    public override void Act(StateControllerMB controller)
    {
        if (controller.interactablePoints != null && controller.interactablePoints.Count > 0)
        {
            GoToTarget(controller);


        }
        else
        {
            // Debug.LogError("GoToAction: controller.target is null");
        }
    }

    private void GoToTarget(StateControllerMB controller)
    {


        controller.navMeshAgent.destination = controller.interactablePoints[0].position;
        controller.navMeshAgent.isStopped = false;
    }
}
