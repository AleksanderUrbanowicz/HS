using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Decision_HaveTarget", menuName = "States/Decisions/Characters/Target Decision")]

public class HaveTargetDecision : EmployeeDecision
{
    public override bool Decide(StateControllerMBBase controller)
    {
        EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;
        return _controller.target != null;
    }
}
