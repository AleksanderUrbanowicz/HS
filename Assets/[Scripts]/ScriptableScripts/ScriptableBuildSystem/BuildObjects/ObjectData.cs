using EditorTools;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    [System.Serializable]

    public class ObjectData
    {
        public string id;
        public List<ParameterBase> currentConditions;  //ex. cleanless 45, condition 0
        public float positionX;
        public float positionY;
        public float positionZ;

        public float rotationX;
        public float rotationY;
        public float rotationZ;
        public float rotationW;
        public ObjectData(string _id, Transform t, List<ParameterBase> _currentConditions)
        {
            id = _id;
            positionX = t.position.x;
            positionY = t.position.y;
            positionZ = t.position.z;
            _currentConditions = currentConditions;
            rotationX = t.rotation.x;
            rotationY = t.rotation.y;
            rotationZ = t.rotation.z;
            rotationW = t.rotation.w;


        }
    }
}