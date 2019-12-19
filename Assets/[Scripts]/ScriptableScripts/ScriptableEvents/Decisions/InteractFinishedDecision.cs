﻿using UnityEngine;
[CreateAssetMenu(fileName = "Decision_InteractFinished", menuName = "States/Decisions/Characters/Interact Finished Decision")]

public class InteractFinishedDecision : Decision
{
    public override bool Decide(StateControllerMBBase controller)
    {
        EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;
        foreach (Transform t in _controller.interactablePoints)
        {
            if (t.transform.position == _controller.target.position)
            {

               // controller.interactablePoints.Remove(controller.target);
                return true;
            }

        }

        return false;

    }
}
