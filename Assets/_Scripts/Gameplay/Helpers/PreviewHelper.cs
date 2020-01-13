using GeneralImplementations.Data;
using Managers;
using UnityEngine;

namespace GeneralImplementations.Managers
{
    public class PreviewHelper : MonoBehaviour
    {
        public PreviewSpawner previewSpawner;
        public ISpawnableBuildObject spawnable;
        public PreviewBuildObject previewBuildObject;
        //public Vector3 lastPoint;
       // public Vector3 lastMappedPoint;
        //public PreviewRaycastHitInterpreter raycastHitInterpreter;
       

        // public RaycastHit RaycastHitOutput { get => MonoBehaviourHookup.RaycastHitOutput; }
        public PreviewData PreviewData { get => SingletonBuildManager.Instance.previewData; set => SingletonBuildManager.Instance.previewData = value; }
        public PreviewBuildObject PreviewObject { get => previewBuildObject; }

        private void ChangePreview(ISpawnableBuildObject _spawnable)
        {
            Debug.LogError("PreviewHelper.ChangePreview(ISpawnableBuildObject)");
            spawnable = _spawnable;
            previewSpawner.CreateInstance(spawnable);
        }

        public PreviewHelper(ISpawnableBuildObject _spawnable)
        {
            Debug.LogError("PreviewHelper(ISpawnableBuildObject)");

            this.spawnable = _spawnable;
            previewSpawner = SingletonBuildManager.Instance.BuildPreviewExecutor.gameObject.AddComponent<PreviewSpawner>();
        }

        public PreviewHelper()

        {
            Debug.LogError("PreviewHelper()");
            if (previewSpawner==null)
            {


            }

        }
        public void Awake()

        {
            Debug.LogError("PreviewHelper.Awake");
            previewSpawner = SingletonBuildManager.Instance.BuildPreviewExecutor.gameObject.AddComponent<PreviewSpawner>();


        }

        public void Start()

        {
            Debug.LogError("PreviewHelper.Start");


        }
        public void UpdateCurrentPreview()
        {
            Debug.LogError("UpdateCurrentPreviewEvent");

           // ChangePreview(SingletonBuildManager.Instance.BuildObjectsHelper.CurrentBuildObject);

        }


    }
}