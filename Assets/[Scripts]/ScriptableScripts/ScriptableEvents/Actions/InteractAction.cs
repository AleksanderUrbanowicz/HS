using UnityEngine;

[CreateAssetMenu(fileName = "InteractAction", menuName = "States/Actions/Characters/Interact Action")]

public class InteractAction : EmployeeAction
{
    public override void Act(StateControllerMBBase controller)
    {
        EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;

        //Debug.Log("InteractAction");
        // throw new System.NotImplementedException();
    }
}
