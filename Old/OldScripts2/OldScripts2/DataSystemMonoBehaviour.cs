using Data;
using Data.Containers;
using Managers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
namespace Managers
{
    public class DataSystemMonoBehaviour : MonoBehaviour
    {
        private GameObject[] objectsToSave;
        ScriptableDataSystem scriptableDataSystem;

        public void Init(ScriptableDataSystem _scriptableDataSystem)
        {
            scriptableDataSystem = _scriptableDataSystem;
            ScriptableSystemManager.Instance.cash = PlayerPrefs.GetInt(scriptableDataSystem.playerPrefsCashKey, 20000);
            ScriptableSystemManager.Instance.dataSystemMonoBehaviour = this;
            InitSpawner();
            // LoadObjects();
        }
        public void GetObjectsToSave()
        {
            objectsToSave = GameObject.FindGameObjectsWithTag(scriptableDataSystem.objectsTag);

        }

        public void SaveObjects()
        {
            GetObjectsToSave();
            List<ObjectData> objectDatas = new List<ObjectData>();
            for (int i = 0; i < objectsToSave.Length; i++)
            {
                GameObject go = objectsToSave[i];
                PluggableObjectMonoBehaviour pluggableObjectMonoBehaviour = go.GetComponent<PluggableObjectMonoBehaviour>();
                if (pluggableObjectMonoBehaviour != null)
                {
                    objectDatas.Add(new ObjectData(go.name, go.transform, pluggableObjectMonoBehaviour.currentConditions, pluggableObjectMonoBehaviour.buildObjectData));

                }
                else
                {
                    Debug.LogWarning("SaveObjects(), Object: " + go.name + ", do not have PluggableObjectMonoBehaviour");
                    objectDatas.Add(new ObjectData(go.name, go.transform, null, pluggableObjectMonoBehaviour.buildObjectData));

                }

            }
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + scriptableDataSystem.objectsDataFilename);
            //JsonUtility.FromJson(,typeof(ObjectData))
            bf.Serialize(file, objectDatas);
            file.Close();
        }

        public void SavePlayerData()
        {

            PlayerData playerData = new PlayerData
            {
                cash = ScriptableSystemManager.Instance.cash
            };
            PlayerPrefs.SetInt(scriptableDataSystem.playerPrefsCashKey, playerData.cash);

        }

        public void LoadObjects()
        {
            if (File.Exists(Application.persistentDataPath + scriptableDataSystem.objectsDataFilename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + scriptableDataSystem.objectsDataFilename, FileMode.Open);
                List<ObjectData> objectDatas = (List<ObjectData>)bf.Deserialize(file);
                file.Close();
                LoadObjects(objectDatas);

            }

        }

        public void DeleteSavedObjects()
        {
            if (File.Exists(Application.persistentDataPath + scriptableDataSystem.objectsDataFilename))
            {
                File.Delete(Application.persistentDataPath + scriptableDataSystem.objectsDataFilename);
            }

        }

        public void LoadObjects(List<ObjectData> _objectDatas)
        {
            foreach (ObjectData od in _objectDatas)
            {
                ScriptableSystemManager.Instance.spawnerHelper.SpawnSavedObject(od);


            }

        }
        public void InitSpawner()
        {
            if (ScriptableSystemManager.Instance.spawnerHelper == null)
            {
                ScriptableSystemManager.Instance.spawnerHelper = new GameObject("spawnerHelper").AddComponent<SpawnerHelper>();
                ScriptableSystemManager.Instance.spawnerHelper.gameObject.transform.parent = gameObject.transform;
                ScriptableSystemManager.Instance.spawnerHelper.Init();

            }

        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                GetObjectsToSave();



            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                SaveObjects();
                Debug.LogError("SaveObjects: " + Application.persistentDataPath + scriptableDataSystem.objectsDataFilename);
                SavePlayerData();
                Debug.LogError("PlayerPrefs.Cash: " + PlayerPrefs.GetInt(scriptableDataSystem.playerPrefsCashKey));

            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                PlayerPrefs.SetInt(scriptableDataSystem.playerPrefsCashKey, 20000);
                Debug.LogError("PlayerPrefs.Cash: " + PlayerPrefs.GetInt(scriptableDataSystem.playerPrefsCashKey));


            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadObjects();

            }
        }

    }
}