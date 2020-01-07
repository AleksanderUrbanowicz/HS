using UnityEngine;
namespace StateMachine
{
    [CreateAssetMenu(fileName = "Decision_Employee_NextTarget", menuName = "States/Decisions/Characters/Next Target Decision")]

    public class NextTargetEmployeeDecision : EmployeeDecision
    {
        public override bool Decide(StateControllerMBBase controller)
        {
            return false;
        }

    }
}