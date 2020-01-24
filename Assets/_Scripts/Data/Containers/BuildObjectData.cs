using BaseLibrary.Data;
using BaseLibrary.Managers;
using GeneralImplementations.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewBuildObjectData", menuName = "ScriptableSystems/Build System/Build Object Data")]
    public class BuildObjectData : ScriptableObject, ISpawnableBuildObject
    {

        public string id;

        public GameObject objectPrefab;
        public Vector3 offset;
        public Vector3 actualSize;
        public Vector3 gridSize;
        public Vector3 orientationVector = Vector3.up;
        public Sprite render;
        //private Dictionary<string, Vector3> sizes;

        public int cost;
        public ObjectOrientation objectOrientation = ObjectOrientation.FLOOR;

        public LayerMask layersToBuildOn;
        public LayerMask obstacleLayers;

        public float collsionBoundsFraction = 0.95f;
        public float rotationStep = 90.0f;

        public List<BuildObjectMaterialData> materialData;

        public PluggableDynamicParams pluggableDynamicParams;


        GameObject ISpawnable.GetPrefab
        {
            get
            {
                return objectPrefab;
            }
        }

        string ISpawnable.GetID
        {
            get
            {
                return id;
            }
        }




        public ScriptableObject GetScriptableObject => this as ScriptableObject;


        BuildObjectData ISpawnableBuildObject.BuildObjectData => this;
    }
}
