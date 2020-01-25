using Data;
using UnityEngine;
namespace Managers
{
    public class PreviewRaycastHitInterpreter : MonoBehaviour
    {
        //private PreviewData previewData;
        
        public PreviewData PreviewData { get => SingletonBuildManager.PreviewData; set => SingletonBuildManager.PreviewData = value; }
        public RaycastExecutorData RaycastExecutorData { get {
          
                return SingletonBuildManager.MonoBehaviourHookup.RaycastExecutorData; } set => SingletonBuildManager.MonoBehaviourHookup.RaycastExecutorData = value; }
        public void Awake()
        {
            
        
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
            if (PreviewData.gridSize < PreviewData.gridSizeEpsilon)
            {
                RaycastExecutorData.lastPoint = _point;
                return true;
            }
            

                float distance = Vector3.Distance(RaycastExecutorData.PreviewObjectTransform.position, _point);
            if (distance > PreviewData.previewSnapFactor * PreviewData.gridSize)
            {
                RaycastExecutorData.lastPoint = _point;
                return true;

            }
            return false;
        }

        public void UpdatePreviewTransform(Vector3 _position)
        {
           
            Vector3 orientationVector = SingletonBuildManager.BuildObjectsHelper.CurrentBuildObject.orientationVector;
            
           
            Vector3 collisionNormal = RaycastExecutorData.RaycastHitOutput.normal;
            if (orientationVector == default)
            {
                orientationVector.y = 1.0f;

            }
            Quaternion Rotation = Quaternion.FromToRotation(orientationVector, collisionNormal);
            Rotation *= Quaternion.Euler(orientationVector * SingletonBuildManager.PreviewBuildObject.userRotationF);
            RaycastExecutorData.PreviewObjectTransform.position = _position;
            RaycastExecutorData.PreviewObjectTransform.rotation = Rotation;
        }
            public Vector3 MapPositionToGrid()
        {
            Vector3 CurrentPosition = RaycastExecutorData.RaycastHitOutput.point;
           
            
                CurrentPosition -= Vector3.one * PreviewData.offset;
                CurrentPosition /= PreviewData.gridSize;
                CurrentPosition = new Vector3(Mathf.Round(CurrentPosition.x), Mathf.Round(CurrentPosition.y), Mathf.Round(CurrentPosition.z));
                CurrentPosition *= PreviewData.gridSize;
                CurrentPosition += Vector3.one * PreviewData.offset;
            

            RaycastExecutorData.lastMappedPoint = CurrentPosition;
            return CurrentPosition;
            
        }

    }
}