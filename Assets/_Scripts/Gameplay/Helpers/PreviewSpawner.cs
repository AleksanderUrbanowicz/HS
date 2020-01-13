using BaseLibrary.Managers;
using GeneralImplementations.Data;
using UnityEngine;

namespace GeneralImplementations.Managers
{
    public class PreviewSpawner : MonoBehaviour, ITempSpawner
    {

        private IPreviewObject previewObject;
        private GameObject instanceGameObject;
        private ISpawnableBuildObject spawnableInstance;

        public PreviewSpawner(ISpawnableBuildObject spawnableInstance)
        {
            this.spawnableInstance = spawnableInstance;
            CreateInstance();
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

        public IPreviewObject PreviewObject
        {
            get
            {
                if (previewObject == null)
                {
                    previewObject = instanceGameObject.GetComponent<IPreviewObject>() != null ? instanceGameObject.GetComponent<IPreviewObject>() : instanceGameObject.AddComponent<PreviewBuildObject>();

                }
                return previewObject;
            }
            set => previewObject = value;
        }

        public GameObject CreateInstance(Transform parent, Vector3 position, Quaternion rotation, ISpawnable _spawnable)
        {
            return CreateInstance(_spawnable as ISpawnableBuildObject);
        }

        public GameObject CreateInstance(ISpawnableBuildObject _spawnable)
        {
            if (instanceGameObject != null)
            {

                DestroyInstance();
            }
            instanceGameObject = Object.Instantiate(_spawnable.GetPrefab, Vector3.zero, Quaternion.identity, transform);
            instanceGameObject.name = _spawnable.GetID;
            spawnableInstance = _spawnable;
            PreviewBuildObject previewBuildObject = instanceGameObject.AddComponent<PreviewBuildObject>();
            previewBuildObject.Init(_spawnable);
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
            InstanceGameObject.SetActive(b);
        }
    }
}