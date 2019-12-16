using UnityEngine;

[CreateAssetMenu(fileName = "Decision_InteractionInRange", menuName = "States/Decisions/InteractionInRangDecision")]


public class InteractionsInRangeDecision : Decision
{
    public float min = 5;
    public override bool Decide(StateControllerMB controller)
    {
        float minDist = 999;
        int index = -1;
        foreach (Transform t in controller.interactablePoints)
        {
            float temp = Vector3.Distance(controller.transform.position, t.position);
            if (temp < minDist)
            {

                minDist = temp;
                index = controller.interactablePoints.IndexOf(t);
            }

        }
        if (minDist < min && index >= 0)
        {
            controller.target = controller.interactablePoints[index];
            return true;

        }
        else
        {
            return false;

        }
    }


}
