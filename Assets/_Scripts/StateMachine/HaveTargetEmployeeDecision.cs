using UnityEngine;
namespace Assets._Scripts.StateMachine
{
    [CreateAssetMenu(fileName = "Decision_Employee_HaveTarget", menuName = "States/Decisions/Characters/Target Decision")]

    public class HaveTargetEmployeeDecision : EmployeeDecision
    {
        public bool setDestinationOnTrue;

        public bool SetDestinationOnTrue { get => setDestinationOnTrue; set => setDestinationOnTrue = value; }

        public override bool Decide(StateControllerMBBase controller)
        {
            EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;
            bool b = _controller.Target != null;
            if (b && SetDestinationOnTrue)
            {
                _controller.NavMeshAgent.SetDestination(_controller.Target.position);
            }
            return b;
        }
    }
}