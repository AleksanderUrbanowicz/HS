using BaseLibrary.Managers;
using BaseLibrary.StateMachine;
using Data;
using GeneralImplementations.Data;
using GeneralImplementations.Managers;
using UnityEngine;
namespace Managers
{
    [CreateAssetMenu(fileName = "Manager_Build", menuName = "Managers/ Singleton Build Manager")]
    public class SingletonBuildManager : ScriptableSingleton<SingletonBuildManager, BuildManagerMonoBehaviourHookup>
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void BeforeSceneLoad() { CreateSingletonInstance(); }

        public BuildObjectsHelper buildObjectsHelper;
        public DebugGizmosData gizmosData;
        public RaycastData rycastData;
        public PreviewData previewData;

        private bool isManagerActive;
        public bool logs = true;
        private BuildManagerMonoBehaviourHookup monoBehaviourHookup;

        public BuildManagerMonoBehaviourHookup MonoBehaviourHookup
        {
            get
            {
                if (monoBehaviourHookup == null)
                {
                    monoBehaviourHookup = _MonoBehaviour.GetComponent<BuildManagerMonoBehaviourHookup>();
                }
                return monoBehaviourHookup;
            }
            set => monoBehaviourHookup = value;
        }
        public RaycastExecutor BuildSystemRaycast { get => MonoBehaviourHookup.buildSystemRaycast; set => MonoBehaviourHookup.buildSystemRaycast = value; }

        public BuildPreviewExecutor BuildPreviewExecutor
        {
            get
            {

                return MonoBehaviourHookup.buildPreviewExecutor;
            }
            set => MonoBehaviourHookup.buildPreviewExecutor = value;
        }

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
    

        public override void Update()
        {
            GetDebugInput();
        }
        public override void Start()
        {
            Debug.LogError(" SingletonBuildManager.Start ID: " + buildObjectsHelper.CurrentBuildObject.id);
            InitRaycaster();
            InitPreviewExecutor(buildObjectsHelper.CurrentBuildObject);
            // StartBuildManager();
            isManagerActive = false;

        }


        public void InitRaycaster()
        {
            MonoBehaviourHookup.buildSystemRaycast = MonoBehaviourHookup.buildSystemRaycast != null ? MonoBehaviourHookup.buildSystemRaycast : monoBehaviourHookup.gameObject.AddComponent<RaycastExecutor>();
            MonoBehaviourHookup.buildSystemRaycast.Init(rycastData);
            MonoBehaviourHookup.buildSystemRaycast.hitMissListeners = new BoolEventListener("BuildRaycast", _MonoBehaviour.transform, rycastData.hitMissEvents.scriptableEventTrue, HandleBuildHit, rycastData.hitMissEvents.scriptableEventFalse, HandleBuildMiss);

        }
        public void InitPreviewExecutor(ISpawnableBuildObject spawnableBuildObject)
        {
            MonoBehaviourHookup.buildPreviewExecutor = MonoBehaviourHookup.buildPreviewExecutor != null ? MonoBehaviourHookup.buildPreviewExecutor : monoBehaviourHookup.gameObject.AddComponent<BuildPreviewExecutor>();
            MonoBehaviourHookup.buildPreviewExecutor.Init(spawnableBuildObject);

        }

        public void GetDebugInput()
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
        public void StartBuildManager()

        {
            Debug.LogError("StartBuildManager");
            BuildPreviewExecutor.TooglePreviewGameObject(true);
            MonoBehaviourHookup.buildSystemRaycast.StartExecute();

        }
        void StopBuildManager()
        {
            Debug.LogError("StoptBuildManager");


            BuildPreviewExecutor.TooglePreviewGameObject(false);
            MonoBehaviourHookup.buildSystemRaycast.StopExecute();

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