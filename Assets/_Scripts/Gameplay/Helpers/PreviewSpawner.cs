using BaseLibrary.Interfaces;
using Data;
using UnityEngine;

namespace Managers
{
    public class PreviewSpawner : MonoBehaviour, ITempSpawner
    {

        public PreviewBuildObject previewObject;
        private GameObject instanceGameObject;
        private ISpawnableBuildObject spawnableInstance;


        public void Awake()
        {



        }

        public void Init(ISpawnableBuildObject spawnableBuildObject)
        {
            spawnableInstance = spawnableBuildObject;
            CreateInstance(spawnableBuildObject);
            //  ToggleInstance(false);


        }
        public GameObject InstanceGameObject
        {
            get
            {
                if (instanceGameObject == null)
                {

                    instanceGameObject = CreateInstance(spawnableInstance);
                }
                return instanceGameObject;
            }
            set { instanceGameObject = value; }
        }

        public ISpawnableBuildObject SpawnableInstance { get { return spawnableInstance; } set => spawnableInstance = value; }

        public PreviewBuildObject PreviewObject
        {
            get
            {
                if (previewObject == null)
                {
                    previewObject = instanceGameObject.GetComponent<PreviewBuildObject>() != null ? instanceGameObject.GetComponent<PreviewBuildObject>() : instanceGameObject.AddComponent<PreviewBuildObject>();

                }
                return previewObject;
            }
            set => previewObject = value;
        }

        public GameObject CreateInstance(Transform parent, Vector3 position, Quaternion rotation, ISpawnable _spawnable)
        {
            instanceGameObject = Instantiate(_spawnable.GetPrefab, position, rotation, parent);
            instanceGameObject.name = _spawnable.GetID;
            spawnableInstance = _spawnable as ISpawnableBuildObject;
            previewObject = instanceGameObject.AddComponent<PreviewBuildObject>();
            PreviewObject.Init(spawnableInstance.BuildObjectData);
            return instanceGameObject;
        }
        public GameObject CreateInstance(ISpawnable _spawnable)
        {
            return CreateInstance(new GameObject(_spawnable.GetID).transform, _spawnable);
        }
        public GameObject CreateInstance(Transform parent, ISpawnable _spawnable)
        {
            return CreateInstance(parent, parent.transform.position, parent.transform.rotation,_spawnable);
        }
        public GameObject CreateInstance(ISpawnableBuildObject _spawnable)
        {
            if (instanceGameObject != null)
            {

                // DestroyInstance();
            }
            instanceGameObject = Instantiate(_spawnable.GetPrefab, Vector3.zero, Quaternion.identity, transform);
            instanceGameObject.name = _spawnable.GetID;
            spawnableInstance = _spawnable;
            previewObject = instanceGameObject.AddComponent<PreviewBuildObject>();
            PreviewObject.Init(_spawnable.BuildObjectData);
            return instanceGameObject;
        }
        public void CreateInstance()
        {
            CreateInstance(spawnableInstance);
        }
        public void DestroyInstance()
        {
            Destroy(instanceGameObject);
        }

        public void ToggleInstance(bool b)
        {
            previewObject.ToggleVisibility(b);
            //InstanceGameObject.SetActive(b);
        }
    }
}