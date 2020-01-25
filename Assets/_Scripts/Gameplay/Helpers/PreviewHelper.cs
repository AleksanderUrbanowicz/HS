using Data;
using UnityEngine;

namespace Managers
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