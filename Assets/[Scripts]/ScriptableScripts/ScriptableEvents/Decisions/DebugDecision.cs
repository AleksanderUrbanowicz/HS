using UnityEngine;
[CreateAssetMenu(fileName = "Decision_Debug", menuName = "States/Decisions/Debug Decision")]

public class DebugDecision : Decision
{
    public bool b;
    public override  bool Decide(StateControllerMBBase controller)
    {
        return b;
        // throw new System.NotImplementedException();
    }
}
