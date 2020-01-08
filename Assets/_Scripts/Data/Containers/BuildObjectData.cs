using BaseLibrary.Managers;
using Data.Definitions;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Containers
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewBuildObjectData", menuName = "ScriptableSystems/Build System/Build Object Data")]
    public class BuildObjectData : ScriptableObject, ISpawnable
    {

        public string id;

        public GameObject objectPrefab;
        public Vector3 offset;
        public Vector3 actualSize;
        public Vector3 gridSize;
        public Vector3 orientationVector = Vector3.up;

        //private Dictionary<string, Vector3> sizes;

        public int cost;
        public ObjectOrientation objectOrientation = ObjectOrientation.FLOOR;

        public LayerMask layersToBuildOn;
        public LayerMask obstacleLayers;

        public float collsionBoundsFraction = 0.95f;
        public float rotationStep = 90.0f;

        public List<BuildObjectMaterialData> materialData;

        public PluggableDynamicParams pluggableDynamicParams;



        public BuildObjectData()
        {

        }



        private void OnEnable()
        {
            if (objectOrientation == ObjectOrientation.WALL)
            {
                orientationVector = Vector3.back;

            }
        }



        GameObject ISpawnable.GetPrefab => objectPrefab;

        string ISpawnable.GetID => id;
    }
}
