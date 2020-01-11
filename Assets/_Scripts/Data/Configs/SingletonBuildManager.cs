using BaseLibrary.Managers;
using BaseLibrary.StateMachine;
using Data;
using GeneralImplementations.Data;
using GeneralImplementations.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "Manager_Build", menuName = "Managers/ Singleton Build Manager")]
    public class SingletonBuildManager : ScriptableSingleton<SingletonBuildManager>
    
    {
     
        private int currentBuildObjectIndex = 0;
        
        private BuildObjectData[] buildObjectsData;
        private BuildObjectData currentBuildObject;
        
        private Quaternion rotation;
        private BuildPreviewExecutor buildPreviewExecutor;
        public RaycastExecutor buildSystemRaycast;
        public BoolEventListener hitMissListeners;

        public RaycastData raycastData;
        public PreviewData previewData;
       // private RaycastExecutorData raycastExecutorData;

        [Header("Debug and Gizmos")]
        public bool logs = false;

        public bool IsShowingPreview { get => BuildPreviewExecutor.isPreviewActive;  }
        public BuildPreviewExecutor BuildPreviewExecutor 
            { get 
                { 
                if(buildPreviewExecutor==null)
                {
                    buildPreviewExecutor = new BuildPreviewExecutor();
                    buildPreviewExecutor.Init(previewData,CurrentBuildObject);
                }
                return buildPreviewExecutor; 
            } set => buildPreviewExecutor = value; }

        public BuildObjectData CurrentBuildObject { 
            get {
                return BuildObjectsData[CurrentBuildObjectIndex]; 
            }
            set => currentBuildObject = value; }

        public int CurrentBuildObjectIndex 
        { 
            get 
            {
           
                
                    return currentBuildObjectIndex; 
            } set => currentBuildObjectIndex = value % BuildObjectsData.Length; }
        public BuildObjectData[] BuildObjectsData { 
            get {
                if (buildObjectsData == null || buildObjectsData.Length == 0)
                {

                    buildObjectsData = Resources.LoadAll<BuildObjectData>("");
                    if (buildObjectsData.Length == 0)
                    {

                        Debug.LogError("No build Objects");
                        _MonoBehaviour.gameObject.SetActive(false);
                        return null;
                    }
                }
                return buildObjectsData; 
            } set => buildObjectsData = value; }

        public void InitEventListeners()
        {
            hitMissListeners = new BoolEventListener("BuildRaycastHit", _MonoBehaviour.transform, raycastData.hitMissEvents.scriptableEventTrue, HandlePreviewHit, raycastData.hitMissEvents.scriptableEventFalse, HandlePreviewMiss);

        }

        public void InitRaycaster()
        {
            buildSystemRaycast = _MonoBehaviour.gameObject.AddComponent<RaycastExecutor>();
         
            buildSystemRaycast.Init(raycastData);

        }

        public void StartBuildManager()
        {
            //BuildPreviewExecutor

        }

        void StopBuildManager()
        {


        }

        public void InitPreview(ISpawnableBuildObject spawnableBuildObject)
        {
          //  BuildPreviewExecutor

        }

        public override void Update()
        {
            Debug.Log(" SingletonBuildManager");
            
        }


        public void HandlePreviewHit()
        {
            if (logs) Debug.Log("HandlePreviewHit");
            // IsShowingPreview = true;
            BuildPreviewExecutor.StartExecute();

        }
        public void HandlePreviewMiss()
        {
            if (logs) Debug.Log("HandlePreviewMiss");
            BuildPreviewExecutor.StopExecute();
            // IsShowingPreview = false;

        }

      

    }
}