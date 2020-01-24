using GeneralImplementations.Data;
using Managers;
using UnityEngine;

namespace GeneralImplementations.Managers
{
    public class PreviewHelper : MonoBehaviour
    {
        public PreviewSpawner previewSpawner;
        public ISpawnableBuildObject spawnable;
        private PreviewBuildObject previewBuildObject;
        private bool isAvailable;
        public PreviewData PreviewData { get => SingletonBuildManager.PreviewData; set => SingletonBuildManager.PreviewData = value; }
        public PreviewBuildObject PreviewBuildObject { get => previewSpawner.previewObject; set => previewSpawner.previewObject = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }

        private void ChangePreview(ISpawnableBuildObject _spawnable)
        {
           // Debug.LogError("PreviewHelper.ChangePreview(ISpawnableBuildObject)");
            spawnable = _spawnable;
            previewSpawner.CreateInstance(spawnable);
           // previewSpawner.PreviewObject.ToggleVisibility(tr);
        }

        public void Awake()

        {
           // Init();
        }
        public void Init()

        {
            if (SingletonBuildManager.MonoBehaviourHookup.PreviewHelper  == null)
            {

                Debug.LogError("BEFORE PreviewHelper.Awake:PreviewHelper == null");
                SingletonBuildManager.MonoBehaviourHookup.PreviewHelper = this;
                Debug.LogError("After PreviewHelper.Awake:PreviewHelper:"+ SingletonBuildManager.MonoBehaviourHookup.BuildPreviewExecutor.PreviewHelper.name);

            }
            if (SingletonBuildManager.MonoBehaviourHookup.BuildPreviewExecutor.PreviewHelper.previewSpawner == null)
            {

                Debug.LogError("PreviewHelper.Awake:previewSpawner == null");
                SingletonBuildManager.MonoBehaviourHookup.BuildPreviewExecutor.PreviewHelper.previewSpawner = this.gameObject.AddComponent<PreviewSpawner>();
                SingletonBuildManager.MonoBehaviourHookup.BuildPreviewExecutor.PreviewHelper.previewSpawner.Init(SingletonBuildManager.BuildObjectsHelper.CurrentBuildObject);
                spawnable = SingletonBuildManager.BuildObjectsHelper.CurrentBuildObject;
            }
           // SingletonBuildManager.Instance.MonoBehaviourHookup.BuildPreviewExecutor.PreviewHelper.previewSpawner = SingletonBuildManager.Instance.MonoBehaviourHookup.gameObject.AddComponent<PreviewSpawner>();
           // spawnable = SingletonBuildManager.Instance.BuildObjectsHelper.CurrentBuildObject;

        }

        public void Start()

        {
           // Debug.Log("PreviewHelper.Start");
            UpdateCurrentPreview();

        }
        public void UpdateCurrentPreview()
        {
           // Debug.LogError("UpdateCurrentPreview");

            ChangePreview(SingletonBuildManager.BuildObjectsHelper.CurrentBuildObject);

        }


    }
}