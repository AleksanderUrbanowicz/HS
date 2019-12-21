using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "Decision_NextWaypoint", menuName = "States/Decisions/Characters/Next Waypoint Decision")]

public class NextWaypointDecision : EmployeeDecision
{
    public float distance = -1;
    [Tooltip("If destination==null  destination = nearest waypoint, instead of next")]
    public bool findNearest = false; // if null destination
    public override bool Decide(StateControllerMBBase controller)
    {
        EmployeeStateControllerMB _controller = controller as EmployeeStateControllerMB;

        if (distance == -1)
        {
            distance = _controller.NavMeshAgent.stoppingDistance;

        }

        if (_controller.NavMeshAgent.destination == null)
        {
            if (findNearest)
            {
                _controller.SetNearestWaypoint();

            }


            _controller.NavMeshAgent.SetDestination(_controller.WayPointList[_controller.nextWayPoint].position);
                _controller.NavMeshAgent.isStopped = false;
                return false;

            }
        if (_controller.NavMeshAgent.remainingDistance <= distance && !_controller.NavMeshAgent.pathPending)
        {
            _controller.nextWayPoint = (_controller.nextWayPoint + 1) % _controller.WayPointList.Count;
            _controller.NavMeshAgent.SetDestination(_controller.WayPointList[_controller.nextWayPoint].position);
            _controller.NavMeshAgent.isStopped = false;
            return true;
        }

        return false;
    }
}
}