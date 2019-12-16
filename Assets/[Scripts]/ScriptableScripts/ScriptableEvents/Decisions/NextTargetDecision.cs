using UnityEngine;

[CreateAssetMenu(fileName = "NextTargetDecision", menuName = "States/Decisions/Next Target Decision")]

public class NextTargetDecision : Decision
{
    public override bool Decide(StateControllerMB controller)
    {
        return false;
    }

}
