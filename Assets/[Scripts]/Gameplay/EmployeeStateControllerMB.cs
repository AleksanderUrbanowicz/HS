using EditorTools;
using ScriptableSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmployeeStateControllerMB : StateControllerMBBase
{
    
    public Transform target;
    public NavMeshAgent navMeshAgent;
    public List<Transform> wayPointList;
    public List<Transform> interactablePoints;
    public int nextWayPoint;
    public int nextInteractablePoint;
   // private bool aiActive;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (wayPointList == null || wayPointList.Count == 0)
        {
            //  wayPointList = new List<Transform>();
            //  wayPointList.Add(new GameObject().transform);
            wayPointList = ScriptableSystemManager.Instance.patrolWaypoints;
        }
        //SetupAI(true);
    }




    public void SetNearestWaypoint()
    {
        float minDist = float.MaxValue;
        int index = -1;
        for (int i = 0; i < wayPointList.Count; i++)
        {
            Vector3 pos = wayPointList[i].position;
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
