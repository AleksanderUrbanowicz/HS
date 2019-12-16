using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Decision_NextWaypoint", menuName = "States/Decisions/Next Waypoint Decision")]

public class NextWaypointDecision : Decision
{
    public float distance = -1;
    [Tooltip("If destination==null  destination = nearest waypoint, instead of next")]
    public bool findNearest = false; // if null destination
    public override bool Decide(StateControllerMB controller)
    {
        if (distance == -1)
        {
            distance = controller.navMeshAgent.stoppingDistance;

        }

        if(controller.navMeshAgent.destination==null)
        {
            if (findNearest)
            {
                controller.SetNearestWaypoint();

            }
            
            
                controller.navMeshAgent.SetDestination(controller.wayPointList[controller.nextWayPoint].position);
            

        }
        if (controller.navMeshAgent.remainingDistance <= distance && !controller.navMeshAgent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            controller.navMeshAgent.SetDestination(controller.wayPointList[controller.nextWayPoint].position);
            controller.navMeshAgent.isStopped = false;
            return true;
        }

        return false;
    }
}
