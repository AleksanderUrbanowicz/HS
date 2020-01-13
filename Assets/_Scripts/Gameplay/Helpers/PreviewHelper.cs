using GeneralImplementations.Data;
using Managers;
using UnityEngine;

namespace GeneralImplementations.Managers
{
    public class PreviewHelper
    {
        public PreviewSpawner previewSpawner;
        public ISpawnableBuildObject spawnable;
        public PreviewBuildObject previewBuildObject;
        public Vector3 lastPoint;
        public Vector3 lastMappedPoint;
        public float userRotationF;

        // public RaycastHit RaycastHitOutput { get => MonoBehaviourHookup.RaycastHitOutput; }
        public PreviewData PreviewData { get => SingletonBuildManager.Instance.previewData; set => SingletonBuildManager.Instance.previewData = value; }
        public PreviewBuildObject PreviewObject { get => previewBuildObject; }

        private void ChangePreview(ISpawnableBuildObject _spawnable)
        {
            spawnable = _spawnable;
            previewSpawner.CreateInstance(spawnable);
        }

        public PreviewHelper(ISpawnableBuildObject _spawnable)
        {
            this.spawnable = _spawnable;
            previewSpawner = new PreviewSpawner(_spawnable);
        }



        public void MapPreviewToGrid(Vector3 _point, Vector3 _normal, Vector3 orientationVector = new Vector3())
        {

            //  Debug.LogError("MapPreviewToGrid");
            Quaternion Rotation;
            Vector3 CurrentPosition;
            // collisionNormal = _normal;
            if (orientationVector == default)
            {
                orientationVector.y = 1.0f;

            }
            Rotation = Quaternion.FromToRotation(orientationVector, _normal);
            Rotation *= Quaternion.Euler(orientationVector * userRotationF);

            CurrentPosition = _point;
            if (PreviewData.gridSize > PreviewData.gridSizeEpsilon)
            {
                CurrentPosition -= Vector3.one * PreviewData.offset;
                CurrentPosition /= PreviewData.gridSize;
                CurrentPosition = new Vector3(Mathf.Round(CurrentPosition.x), Mathf.Round(CurrentPosition.y), Mathf.Round(CurrentPosition.z));
                CurrentPosition *= PreviewData.gridSize;
                CurrentPosition += Vector3.one * PreviewData.offset;
            }


            PreviewObject.transform.position = CurrentPosition;

            PreviewObject.transform.rotation = Rotation;
            lastMappedPoint = CurrentPosition;
            PreviewData.gridSnapEvent.Raise();
        }
        public void UpdateCurrentPreview()
        {
            Debug.LogError("UpdateCurrentPreviewEvent");

            ChangePreview(SingletonBuildManager.Instance.BuildObjectsHelper.CurrentBuildObject);

        }


    }
}