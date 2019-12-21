using Characters;
using EditorTools;
using Interfaces;
using Objects;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class SpawnerHelper : MonoBehaviour
    {
        public Transform objectsTransform;
        public Transform charactersTransform;
        ISpawner spawner = new Spawner();



        public void Init()
        {
            if (objectsTransform == null)
            {
               
                objectsTransform = new GameObject("BuildObjects").transform;
            }
            if (charactersTransform == null)
            {
                charactersTransform = new GameObject("Characters").transform;
            }
            ScriptableSystemManager.Instance.spawnerHelper = this;
        }
        public void SpawnSavedObject(ObjectData od)
        {
            BuildObjectData buildObjectData = ScriptableSystemManager.Instance.gameSettings.GetBuildObjectData(od.id);

            Vector3 position = new Vector3(od.positionX, od.positionY, od.positionZ);
            Quaternion rotation = new Quaternion(od.rotationX, od.rotationY, od.rotationZ, od.rotationW);
            List<DynamicParameter> savedConditions = od.currentConditions;
            GameObject instance= spawner.CreateInstance(objectsTransform, position, rotation, (buildObjectData as ISpawnable));
            //GameObject instance = (buildObjectData as ICreateInstance).CreateInstance(parentTransform,position, rotation);
            PluggableObjectMonoBehaviour mb = instance.GetComponent<PluggableObjectMonoBehaviour>();
            if (mb == null)
            {
                mb = instance.AddComponent<PluggableObjectMonoBehaviour>();

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

            GameObject instance = spawner.CreateInstance(objectsTransform, position, rotation, (data as ISpawnable));

            //GameObject instance = (data as ICreateInstance).CreateInstance(parentTransform,position, rotation);
            PluggableObjectMonoBehaviour mb = instance.GetComponent<PluggableObjectMonoBehaviour>();
            if (mb == null)
            {
                mb = instance.AddComponent<PluggableObjectMonoBehaviour>();

            }
            mb.Init(data);

            return instance;
        }

        public GameObject SpawnCharacter(PluggableCharacterData data,Transform parent, Vector3 position, Quaternion rotation)
        {
           
                GameObject instance= spawner.CreateInstance(charactersTransform, position, rotation, (data as ISpawnable));
            instance.GetComponent<PluggableCharacterMonoBehaviour>().Init(data);
            return instance;
        }
        public GameObject SpawnCharacter(PluggableCharacterData data, Vector3 position, Quaternion rotation)
        {
            return SpawnCharacter(data, charactersTransform, position, rotation);
        }

    }
}