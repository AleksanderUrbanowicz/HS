using Gameplay;
using Player;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
namespace ScriptableSystems
{
    public class DataSystemMonoBehaviour : MonoBehaviour
    {
        public GameObject[] objectsToSave;
        ScriptableDataSystem scriptableDataSystem;
        public SpawnerHelper spawnerHelper;

        public void Init(ScriptableDataSystem _scriptableDataSystem)
        {
            scriptableDataSystem = _scriptableDataSystem;
            GameManager.instance.cash = PlayerPrefs.GetInt(scriptableDataSystem.playerPrefsCashKey, 20000);
            GameManager.instance.dataSystemMonoBehaviour = this;
            InitSpawner();
            LoadObjects();
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
                objectDatas.Add(new ObjectData(go.name, go.transform));

            }
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + scriptableDataSystem.objectsDataFilename);
            bf.Serialize(file, objectDatas);
            file.Close();
        }

        public void SavePlayerData()
        {

            PlayerData playerData = new PlayerData();
            playerData.cash = GameManager.instance.cash;
            PlayerPrefs.SetInt(scriptableDataSystem.playerPrefsCashKey, playerData.cash);
            //  BinaryFormatter bf = new BinaryFormatter();
            //  FileStream file = File.Create(Application.persistentDataPath + scriptableDataSystem.playerDataFilename);
            //  bf.Serialize(file, playerData);
            //  file.Close();
        }

        public void LoadObjects()
        {
            if (File.Exists(Application.persistentDataPath + scriptableDataSystem.objectsDataFilename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + scriptableDataSystem.objectsDataFilename, FileMode.Open);
                List<ObjectData> objectDatas = (List<ObjectData>)bf.Deserialize(file);
                file.Close();
                foreach (ObjectData od in objectDatas)
                {
                    spawnerHelper.SpawnObject(od);

                }
                // SpawnLoadedObjects(objectDatas);
            }

        }

        public void SpawnLoadedObjects(List<ObjectData> _objectDatas)
        {
            foreach (ObjectData od in _objectDatas)
            {


            }

        }
        public void InitSpawner()
        {
            spawnerHelper = new GameObject("spawnerHelper").AddComponent<SpawnerHelper>();
            spawnerHelper.gameObject.transform.parent = gameObject.transform;
            spawnerHelper.Init();

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