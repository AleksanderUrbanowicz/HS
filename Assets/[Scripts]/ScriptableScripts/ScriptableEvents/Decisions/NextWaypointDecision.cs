using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            distance = _controller.navMeshAgent.stoppingDistance;

        }

        if(_controller.navMeshAgent.destination==null)
        {
            if (findNearest)
            {
                _controller.SetNearestWaypoint();

            }
            
            
                _controller.navMeshAgent.SetDestination(_controller.wayPointList[_controller.nextWayPoint].position);
            

        }
        if (_controller.navMeshAgent.remainingDistance <= distance && !_controller.navMeshAgent.pathPending)
        {
            _controller.nextWayPoint = (_controller.nextWayPoint + 1) % _controller.wayPointList.Count;
            _controller.navMeshAgent.SetDestination(_controller.wayPointList[_controller.nextWayPoint].position);
            _controller.navMeshAgent.isStopped = false;
            return true;
        }

        return false;
    }
}
