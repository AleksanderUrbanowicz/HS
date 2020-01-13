using GeneralImplementations.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Managers
{
    public class PreviewRaycastHitInterpreter : MonoBehaviour
    {
        [SerializeField]
        private RaycastExecutorData raycastExecutorData;


        private PreviewData previewData;
        public float userRotationF;
        public PreviewData PreviewData { get => previewData; set => previewData = value; }
        public RaycastExecutorData RaycastExecutorData { get {
                if(raycastExecutorData==null)
                {
                    Debug.LogError("PreviewRaycastHitInterpreter.RaycastExecutorData == null");
                    raycastExecutorData = gameObject.AddComponent<RaycastExecutorData>();

                }
                return raycastExecutorData; } set => raycastExecutorData = value; }

        public PreviewRaycastHitInterpreter(Transform previewObjectTransform)
        {
            Debug.LogError("PreviewRaycastHitInterpreter(Transform)");
            RaycastExecutorData.previewObjectTransform = previewObjectTransform;
            PreviewData = SingletonBuildManager.Instance.previewData;

        }
        public PreviewRaycastHitInterpreter()
        {
            Debug.LogError("PreviewRaycastHitInterpreter()");
            //RaycastExecutorData.previewObjectTransform = SingletonBuildManager.Instance.BuildPreviewExecutor.PreviewHelper.PreviewObject.transform;
            PreviewData = SingletonBuildManager.Instance.previewData;
        }
        public bool CheckRaycastDelta()
        {
            // Debug.LogError("CheckRaycastDelta");
            Vector3 _point = RaycastExecutorData.RaycastHitOutput.point;
            if (RaycastExecutorData.lastPoint == _point)
            {
                return false;
            }


            float distance = Vector3.Distance(RaycastExecutorData.previewObjectTransform.position, _point);
            if (distance > PreviewData.previewSnapFactor * PreviewData.gridSize)
            {
                RaycastExecutorData.lastPoint = _point;
                return true;

            }
            return false;
        }


        public void MapPreviewToGrid()
        {
            Vector3 _point = RaycastExecutorData.RaycastHitOutput.point;
            Vector3 _normal = RaycastExecutorData.RaycastHitOutput.normal;
            Vector3 orientationVector = SingletonBuildManager.Instance.BuildObjectsHelper.CurrentBuildObject.orientationVector;
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


            RaycastExecutorData.previewObjectTransform.position = CurrentPosition;

            RaycastExecutorData.previewObjectTransform.rotation = Rotation;
            RaycastExecutorData.lastMappedPoint = CurrentPosition;
            PreviewData.gridSnapEvent.Raise();
        }

    }
}