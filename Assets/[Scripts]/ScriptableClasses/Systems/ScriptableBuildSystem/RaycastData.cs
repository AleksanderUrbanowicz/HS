using StateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "RaycastData_BuildSystemRaycast", menuName = "ScriptableSystems/Build System/Raycast Data Asset")]

public class RaycastData : ScriptableObject
{
    public string buildObjectLayerString;
    public LayerMask defaultLayerToBuildOn;

    public float raycastMaxDistance;
    [Tooltip("Events to notify when hit<->miss")]
    public BoolEventGroup hitMissEvents;
    [Tooltip("Number of Updates to skip  per one executed")]
    public int raycastInterval;
    [Tooltip("Stop executing after first succesfull hit")]
    public bool stopAfterHit;
}
