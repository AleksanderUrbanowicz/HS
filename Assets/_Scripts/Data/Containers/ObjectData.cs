using GeneralImplementations.Data;
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
        public float[] positionAndRotation;
       
        public ObjectData(string _id, Transform t, List<DynamicParameter> _currentConditions, BuildObjectData _buildObjectData)
        {
            id = _id;
            positionAndRotation = new float[7];
            buildObjectData = _buildObjectData;
            positionAndRotation[0]= t.position.x;
            positionAndRotation[0] = t.position.y;
            positionAndRotation[0] = t.position.z;
            positionAndRotation[0] = t.rotation.x;
            positionAndRotation[0] = t.rotation.y;
            positionAndRotation[0] = t.rotation.z;
            positionAndRotation[0] = t.rotation.w;

          


        }
    }
}