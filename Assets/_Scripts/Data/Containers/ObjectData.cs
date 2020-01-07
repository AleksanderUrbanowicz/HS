using Data.Containers;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]

    public class ObjectData
    {
        public string id;
        public BuildObjectData buildObjectData;
        public List<DynamicParameter> currentConditions;
        public float positionX;
        public float positionY;
        public float positionZ;

        public float rotationX;
        public float rotationY;
        public float rotationZ;
        public float rotationW;
        public ObjectData(string _id, Transform t, List<DynamicParameter> _currentConditions, BuildObjectData _buildObjectData)
        {
            id = _id;
            buildObjectData = _buildObjectData;
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