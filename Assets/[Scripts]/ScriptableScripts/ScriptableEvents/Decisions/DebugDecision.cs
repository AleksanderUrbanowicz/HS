using UnityEngine;
[CreateAssetMenu(fileName = "Decision_Debug", menuName = "States/Decisions/Debug Decision")]

public class DebugDecision : Decision
{
    public bool b;
    public override bool Decide(StateControllerMB controller)
    {
        return b;
        // throw new System.NotImplementedException();
    }
}
