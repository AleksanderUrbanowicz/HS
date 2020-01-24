using Data;
using GeneralImplementations.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Managers
{
    public class PreviewRaycastHitInterpreter : MonoBehaviour
    {
        //private PreviewData previewData;
        public float userRotationF;
        public PreviewData PreviewData { get => SingletonBuildManager.PreviewData; set => SingletonBuildManager.PreviewData = value; }
        public RaycastExecutorData RaycastExecutorData { get {
          
                return SingletonBuildManager.MonoBehaviourHookup.RaycastExecutorData; } set => SingletonBuildManager.MonoBehaviourHookup.RaycastExecutorData = value; }
        public void Awake()
        {
          //  Debug.LogError("PreviewRaycastHitInterpreter.Awake()");
           // Init();
        }
      
        public void Init()
        {
            Debug.Log("PreviewRaycastHitInterpreter.Init()");
            if(SingletonBuildManager.MonoBehaviourHookup.BuildPreviewExecutor.RaycastHitInterpreter==null)
            {
                SingletonBuildManager.MonoBehaviourHookup.BuildPreviewExecutor.RaycastHitInterpreter = this;

            }
           // SingletonBuildManager.MonoBehaviourHookup.BuildPreviewExecutor.RaycastHitInterpreter = this;
            //RaycastExecutorData.previewObjectTransform = SingletonBuildManager.BuildPreviewExecutor.PreviewHelper.PreviewObject.transform;
            //previewData = SingletonBuildManager.PreviewData;
        }
        public bool CheckRaycastDelta()
        {
            // Debug.LogError("CheckRaycastDelta");
            Vector3 _point = RaycastExecutorData.RaycastHitOutput.point;
            if (RaycastExecutorData.lastPoint == _point)
            {
                return false;
            }


            float distance = Vector3.Distance(RaycastExecutorData.PreviewObjectTransform.position, _point);
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
            Vector3 orientationVector = SingletonBuildManager.BuildObjectsHelper.CurrentBuildObject.orientationVector;
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



           
            RaycastExecutorData.lastMappedPoint = CurrentPosition;
            RaycastExecutorData.PreviewObjectTransform.position = CurrentPosition;
            RaycastExecutorData.PreviewObjectTransform.rotation = Rotation;

            PreviewData.gridSnapEvent.Raise();
        }

    }
}