using UnityEngine;
namespace StateMachine.Decisions
{
    [CreateAssetMenu(fileName = "Decision_NextTarget", menuName = "States/Decisions/Characters/Next Target Decision")]

public class NextTargetDecision : EmployeeDecision
{
    public override bool Decide(StateControllerMBBase controller)
    {
        return false;
    }

}
}