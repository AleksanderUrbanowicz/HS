using UnityEngine;

[CreateAssetMenu(fileName = "Decision_Timed", menuName = "States/Decisions/Timed Decision")]

public class TimedDecision : Decision
{
    public float time;
    public override bool Decide(StateControllerMB controller)
    {
        bool noEnemyInSight = controller.CheckIfCountDownElapsed(time);
        return noEnemyInSight;
    }
}
