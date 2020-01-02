using UnityEngine;
namespace Assets._Scripts.StateMachine
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