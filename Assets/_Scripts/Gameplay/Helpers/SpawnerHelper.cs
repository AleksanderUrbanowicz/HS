using BaseLibrary.Implementations;
using BaseLibrary.Interfaces;
using Data;
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
            //ScriptableSystemManager.Instance.spawnerHelper = this;
        }
        public void SpawnSavedObject(ObjectData od)
        {
            //BuildObjectData buildObjectData = ScriptableSystemManager.Instance.gameSettings.GetBuildObjectData(od.id);

            Vector3 position = new Vector3(od.positionAndRotation[0], od.positionAndRotation[1], od.positionAndRotation[2]);
            Quaternion rotation = new Quaternion(od.positionAndRotation[3], od.positionAndRotation[4], od.positionAndRotation[5],od.positionAndRotation[6]);
            List<DynamicParameter> savedConditions = od.currentConditions;
            GameObject instance = spawner.CreateInstance(objectsTransform, position, rotation, (od.buildObjectData as ISpawnable));
            //GameObject instance = (buildObjectData as ICreateInstance).CreateInstance(parentTransform,position, rotation);
            PluggableObjectMonoBehaviour mb = instance.GetComponent<PluggableObjectMonoBehaviour>();
            if (mb == null)
            {
                mb = instance.AddComponent<PluggableObjectMonoBehaviour>();

            }
            mb.Init(od.buildObjectData, savedConditions);
            instance.name = od.buildObjectData.id;
      
        }

        public GameObject SpawnObject(BuildObjectData data, Vector3 position, Quaternion rotation)
        {
            // Debug.LogError("Spawnerhelper.SpawnObject");

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

        public GameObject SpawnCharacter(PluggableCharacterData data, Transform parent, Vector3 position, Quaternion rotation)
        {

            GameObject instance = spawner.CreateInstance(charactersTransform, position, rotation, (data as ISpawnable));
            instance.GetComponent<PluggableCharacterMonoBehaviour>().Init(data);
            return instance;
        }
        public GameObject SpawnCharacter(PluggableCharacterData data, Vector3 position, Quaternion rotation)
        {
            return SpawnCharacter(data, charactersTransform, position, rotation);
        }

    }
}