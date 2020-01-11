using BaseLibrary.Managers;
using BaseLibrary.StateMachine;
using Data;
using GeneralImplementations.Data;
using GeneralImplementations.Managers;
using UnityEngine;
namespace Managers
{
    [CreateAssetMenu(fileName = "Manager_Build", menuName = "Managers/ Singleton Build Manager")]
    public class SingletonBuildManager : ScriptableSingleton<SingletonBuildManager>
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void BeforeSceneLoad() { CreateSingletonInstance(); }
        private int currentBuildObjectIndex = 0;
        private bool isManagerActive;
        public bool logs = true;
        private BuildObjectData[] buildObjectsData;
        public RaycastData rycastData;
        [SerializeField] public PreviewData previewData;
        [SerializeField] private RaycastExecutorData raycastExecutorData;
        private MonoBehaviourHookup monoBehaviourHookup;
        public bool IsShowingPreview { get => BuildPreviewExecutor.IsExecuting; }
        public BuildPreviewExecutor BuildPreviewExecutor
        {
            get
            {
               
                return MonoBehaviourHookup.buildPreviewExecutor;
            }
            set => MonoBehaviourHookup.buildPreviewExecutor = value;
        }
        public BuildObjectData CurrentBuildObject
        {
            get
            {
                return BuildObjectsData[CurrentBuildObjectIndex];
            }

        }
        public int CurrentBuildObjectIndex
        {
            get
            {
                return currentBuildObjectIndex;
            }
            set => currentBuildObjectIndex = value % BuildObjectsData.Length;
        }
        public BuildObjectData[] BuildObjectsData
        {
            get
            {
                if (buildObjectsData == null || buildObjectsData.Length == 0)
                {

                    buildObjectsData = Resources.LoadAll<BuildObjectData>("");
                    if (buildObjectsData.Length == 0)
                    {

                        Debug.LogError("No build Objects");
                        StopBuildManager();

                        return null;
                    }
                }
                return buildObjectsData;
            }
            set => buildObjectsData = value;
        }
        public RaycastExecutorData RaycastExecutorData { get { 
                if(raycastExecutorData==null)
                {
                    raycastExecutorData = new RaycastExecutorData();

                }
                return raycastExecutorData; } set => raycastExecutorData = value; }
        public bool IsManagerActive
        {
            get
            {
                return isManagerActive;
            }

            set
            {

                if (value != isManagerActive)
                {
                    isManagerActive = value;
                    if (value)
                    {
                        StartBuildManager();
                    }
                    else
                    {

                        StopBuildManager();
                    }
                }

            }
}
        public MonoBehaviourHookup MonoBehaviourHookup { get { 
                if(monoBehaviourHookup==null)
                {
                    monoBehaviourHookup = _MonoBehaviour.GetComponent<MonoBehaviourHookup>();
                }
                return monoBehaviourHookup; } set => monoBehaviourHookup = value; }
        public RaycastExecutor BuildSystemRaycast { get => MonoBehaviourHookup.buildSystemRaycast; set => MonoBehaviourHookup.buildSystemRaycast = value; }
        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                IsManagerActive = true;
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                IsManagerActive = false;
            }
        }
        public override void Start()
        {
            Debug.LogError(" SingletonBuildManager.Start ID: " + CurrentBuildObject.id);
            InitRaycaster();
            InitPreviewExecutor(CurrentBuildObject);
            // StartBuildManager();

        }

        public void InitRaycaster()
        {
           // RaycastExecutorData = new RaycastExecutorData();
            MonoBehaviourHookup.buildSystemRaycast = _MonoBehaviour.gameObject.AddComponent<RaycastExecutor>();

            MonoBehaviourHookup.buildSystemRaycast.Init(rycastData);

            MonoBehaviourHookup.buildSystemRaycast.hitMissListeners = new BoolEventListener("BuildRaycast", MonoBehaviourHookup.transform, rycastData.hitMissEvents.scriptableEventTrue, HandleBuildHit, rycastData.hitMissEvents.scriptableEventFalse, HandleBuildMiss);

            

        }
        public void InitPreviewExecutor(ISpawnableBuildObject spawnableBuildObject)
        {
            //RaycastExecutorData = new RaycastExecutorData();
            if (BuildPreviewExecutor == null)
            {
                BuildPreviewExecutor = _MonoBehaviour.gameObject.AddComponent<BuildPreviewExecutor>();

            }

            BuildPreviewExecutor.Init(previewData, spawnableBuildObject);

        }
        public void StartBuildManager()

        {
            Debug.LogError("StartBuildManager");
            //IsManagerActive = true;
            MonoBehaviourHookup.buildSystemRaycast.StartExecute();
           // BuildPreviewExecutor.StartExecute();
           // _MonoBehaviour.gameObject.SetActive(true);

        }
        void StopBuildManager()
        {
            Debug.LogError("StoptBuildManager");

            // IsManagerActive = false;
            BuildPreviewExecutor.StopExecute();
           // MonoBehaviourHookup.buildSystemRaycast.StopExecute();
          //  _MonoBehaviour.gameObject.SetActive(false);

        }
        
        public void HandleBuildHit()
        {
            if (logs) Debug.Log("HandleBuildHit");
            // IsShowingPreview = true;
            BuildPreviewExecutor.StartExecute();

        }
        public void HandleBuildMiss()
        {
            if (logs) Debug.Log("HandleBuildMiss");
            BuildPreviewExecutor.StopExecute();
            // IsShowingPreview = false;

        }



    }
}