using UnityEngine;
namespace StateMachine.Decisions
{
    [CreateAssetMenu(fileName = "Decision_Employee_ArrivedAtDestination", menuName = "States/Decisions/Characters/Arrived At Destination Decision")]

    public class ArrivedAtDestinationEmployeeDecision : EmployeeDecision
    {
        private float distance = -1;

        public float Distance { get { return distance; } set { distance = value; } }

        public override bool Decide(StateControllerMBBase controller)
        {
            EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;

            if (Distance == -1)
            {
                Distance = _controller.NavMeshAgent.stoppingDistance;

            }

            if (_controller.NavMeshAgent.remainingDistance <= Distance && !_controller.NavMeshAgent.pathPending)
            {
                return true;
            }
            return false;
        }

    }


}
