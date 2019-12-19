using UnityEngine;

[CreateAssetMenu(fileName = "GoToAction", menuName = "States/Actions/Characters/Go To Action")]

public class GoToTargetAction : EmployeeAction
{
    public override void Act(StateControllerMBBase controller)
    {
        EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;

        if (_controller.target!=null)
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


        controller.navMeshAgent.destination = controller.target.position;
        controller.navMeshAgent.isStopped = false;
    }
}
