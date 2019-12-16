using UnityEngine;

[CreateAssetMenu(fileName = "Decision_NextTarget", menuName = "States/Decisions/Next Target Decision")]

public class NextTargetDecision : Decision
{
    public override bool Decide(StateControllerMB controller)
    {
        return false;
    }

}
