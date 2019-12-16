using UnityEngine;
[CreateAssetMenu(fileName = "Decision_InteractFinished", menuName = "States/Decisions/Interact Finished Decision")]

public class InteractFinishedDecision : Decision
{
    public override bool Decide(StateControllerMB controller)
    {
        //reimpl
        foreach (Transform t in controller.interactablePoints)
        {
            if (t.transform.position == controller.target.position)
            {

               // controller.interactablePoints.Remove(controller.target);
                return true;
            }

        }

        return false;

    }
}
