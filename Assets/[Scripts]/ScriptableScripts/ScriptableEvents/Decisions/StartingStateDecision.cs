using UnityEngine;

[CreateAssetMenu(fileName = "Decision_Start_State", menuName = "States/Decisions/Start State Decision")]

public class StartingStateDecision : Decision
{


    public override bool Decide(StateControllerMB controller)
    {
        bool targetIsActive = controller.target != null;
        return targetIsActive;
    }

}
