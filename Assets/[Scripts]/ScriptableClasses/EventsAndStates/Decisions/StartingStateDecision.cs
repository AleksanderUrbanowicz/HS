using UnityEngine;
namespace StateMachine.Decisions
{
    [CreateAssetMenu(fileName = "Decision_Start_State", menuName = "States/Decisions/Characters/Start State Decision")]

public class StartingStateDecision : EmployeeDecision
{


    public override bool Decide(StateControllerMBBase controller)
    {
        EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;
        bool targetIsActive = _controller.Target != null;
        return targetIsActive;
    }

}
}