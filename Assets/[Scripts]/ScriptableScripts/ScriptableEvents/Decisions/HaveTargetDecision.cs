using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Decision_HaveTarget", menuName = "States/Decisions/Target Decision")]

public class HaveTargetDecision : Decision
{
    public override bool Decide(StateControllerMB controller)
    {
        return controller.target != null;
    }
}
