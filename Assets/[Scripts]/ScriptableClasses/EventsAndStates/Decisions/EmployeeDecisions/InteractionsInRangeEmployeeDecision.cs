using UnityEngine;
namespace StateMachine.Decisions
{
    [CreateAssetMenu(fileName = "Decision_Employee_InteractionInRange", menuName = "States/Decisions/Characters/InteractionInRangDecision")]


    public class InteractionsInRangeEmployeeDecision : EmployeeDecision
    {
        public float min = 5;
        public override bool Decide(StateControllerMBBase controller)
        {
            EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;
            float minDist = 999;
            int index = -1;
            foreach (Transform t in _controller.interactablePoints)
            {
                float temp = Vector3.Distance(controller.transform.position, t.position);
                if (temp < minDist)
                {

                    minDist = temp;
                    index = _controller.interactablePoints.IndexOf(t);
                }

            }
            if (minDist < min && index >= 0)
            {
                _controller.Target = _controller.interactablePoints[index];
                return true;

            }

            return false;


        }


    }
}
