using Managers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace StateMachine
{
    public class EmployeeStateControllerMB : StateControllerMBBase
    {
        private NavMeshAgent navMeshAgent;
        private List<Transform> wayPointList;
        public List<Transform> interactablePoints;
        public int nextWayPoint;
        public int nextInteractablePoint;

        public List<Transform> WayPointList
        {
            get
            {
                if (wayPointList == null)
                {
                    wayPointList = ScriptableSystemManager.Instance.patrolWaypoints;
                }
                return wayPointList;
            }
            set
            {
                wayPointList = value;
            }
        }

        public Transform Target { get; set; }
        public NavMeshAgent NavMeshAgent
        {
            get
            {
                if (navMeshAgent == null)
                {
                    navMeshAgent = GetComponent<NavMeshAgent>() != null ? GetComponent<NavMeshAgent>() : gameObject.AddComponent<NavMeshAgent>();

                }
                return navMeshAgent;
            }

        }



        public void SetNearestWaypoint()
        {
            float minDist = float.MaxValue;
            int index = -1;
            for (int i = 0; i < WayPointList.Count; i++)
            {
                Vector3 pos = WayPointList[i].position;
                float temp = Vector3.SqrMagnitude(pos - transform.position);
                if (temp < minDist)
                {

                    minDist = temp;
                    index = i;
                }

            }
            if (index >= 0)
            {

                nextWayPoint = index;
            }
        }


    }
}
