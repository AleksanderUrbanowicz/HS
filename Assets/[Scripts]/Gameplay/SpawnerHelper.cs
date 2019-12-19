using EditorTools;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    public class SpawnerHelper : MonoBehaviour
    {
        public Transform parentTransform;


        public void Init()
        {
            if (parentTransform == null)
            {
                parentTransform = new GameObject("BuildObjects").transform;
            }
            ScriptableSystemManager.Instance.spawnerHelper = this;
        }
        public void SpawnSavedObject(ObjectData od)
        {
            BuildObjectData buildObjectData = ScriptableSystemManager.Instance.gameSettings.GetBuildObjectData(od.id);
         
            Vector3 position = new Vector3(od.positionX, od.positionY, od.positionZ);
            Quaternion rotation = new Quaternion(od.rotationX, od.rotationY, od.rotationZ, od.rotationW);
            List<DynamicParameter> savedConditions = od.currentConditions;
            GameObject instance=  buildObjectData.CreateInstance(position, rotation, parentTransform);
            PluggableObjectMonoBehaviour mb = instance.GetComponent<PluggableObjectMonoBehaviour>();
            if(mb==null)
            {
                mb= instance.AddComponent<PluggableObjectMonoBehaviour>();

            }
            mb.Init(buildObjectData, savedConditions);
            instance.name = buildObjectData.id;
            instance.layer = LayerMask.NameToLayer(ScriptableSystemManager.Instance.gameSettings.scriptableBuildSystem.buildObjectLayerString);

            instance.transform.parent = ScriptableSystemManager.Instance.buildSystemMonoBehaviour.buildObjectsParent;
            instance.tag = ScriptableSystemManager.Instance.gameSettings.scriptableBuildSystem.buildObjectLayerString;

        }

        public GameObject SpawnObject(BuildObjectData data, Vector3 position, Quaternion rotation)
        {
            Debug.LogError("Spawnerhelper.SpawnObject");

  
            GameObject instance =data.CreateInstance(position, rotation, parentTransform);
            PluggableObjectMonoBehaviour mb = instance.GetComponent<PluggableObjectMonoBehaviour>();
            if (mb == null)
            {
                mb = instance.AddComponent<PluggableObjectMonoBehaviour>();

            }
            mb.Init(data);

            return instance;
        }

    }
}