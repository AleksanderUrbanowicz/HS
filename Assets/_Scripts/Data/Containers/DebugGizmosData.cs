using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Debug_GizmosData", menuName = "Data/ Debug Gizmos data")]

public class DebugGizmosData : ScriptableObject
{
    public float mainAxisLength = 15.0f;


    public Vector3 cornerAxisVector = new Vector3(-5, 0, -5);
    public Vector3 collisionNormal;

    public Rect horizontalSmall = new Rect(Vector2.zero, new Vector2(100, 45));
    public Rect horizontalMedium = new Rect(Vector2.zero, new Vector2(150, 60));
}
