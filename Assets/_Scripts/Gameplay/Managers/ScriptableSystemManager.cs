using Assets._Scripts.Data.Configs;
using Assets._Scripts.Data.Containers;
using Assets._Scripts.Gameplay.Helpers;
using Assets._Scripts.Gameplay.MonoBehaviourHookups;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.Gameplay.Managers
{
    // Class: ScriptableSystemManager
    //  MonoBehaviour script for managing scriptable systems of different levels
    public class ScriptableSystemManager : MonoBehaviour
    {
        private static ScriptableSystemManager instance;
        public static ScriptableSystemManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<ScriptableSystemManager>();
                }
                return instance;
            }
        }

        [SerializeField]
        public int cash;
        // public IScriptableManager systemsManager;
        public List<IScriptableManager> _managers = new List<IScriptableManager>();


        public DataSystemMonoBehaviour dataSystemMonoBehaviour;
        public BuildSystemMonoBehaviour buildSystemMonoBehaviour;
        public SpawnerHelper spawnerHelper;
        public GameSettings gameSettings;
        public Text infoText;
        public Transform charactersTransform;
        public Transform systemsTansform;
        public List<Transform> patrolWaypoints = new List<Transform>();
        public List<Transform> interactablePoints = new List<Transform>();
        public PluggableRuntimeCollection Set;
        //private int previousCount = -1;

        private void OnEnable()
        {

        }

        void Awake()
        {
            Debug.LogError(SelectManager.Instance.raycastData.raycastMaxDistance++);
            /// if (systemsManager)
            //// {
            //     _managers.Add(systemsManager);
            //  }
            DontDestroyOnLoad(gameObject);
            if (ScriptableSystemManager.instance == null)
            {
                ScriptableSystemManager.instance = this;
            }
#if UNITY_EDITOR

            if (gameSettings == null)
            {
                gameSettings = EditorStaticTools.GetFirstInstance<GameSettings>();
            }
#endif
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                spawnerHelper.SpawnCharacter(gameSettings.debugCharactersToSpawn[0], charactersTransform.gameObject.transform, new Vector3(0, 0, 0), Quaternion.identity);
                //(gameSettings.debugCharactersToSpawn[0] as ICreateInstance).CreateInstance(charactersTransform.gameObject.transform, new Vector3(0, 0, 0), Quaternion.identity);

            }

        }

        void Start()
        {
            foreach (IScriptableManager manager in _managers)
            {
                manager.Initialize(new GameObject());
            }

            InitSpawner();
            if (gameSettings.charactersRandomSpread == null || gameSettings.charactersRandomSpread == Vector2Int.zero)
            {
                gameSettings.charactersRandomSpread = Vector2Int.one;

            }
            if (systemsTansform == null)
            {
                systemsTansform = new GameObject("SystemsTansform").transform;
            }
            foreach (ScriptableSystem scriptableSystem in gameSettings.scriptableSystems)
            {

                if (scriptableSystem.initializeOnStart)
                {
                    GameObject systemGO = new GameObject();
                    systemGO.transform.parent = systemsTansform;
                    scriptableSystem.Initialize(systemGO);
                }

            }



            if (charactersTransform == null)
            {
                charactersTransform = new GameObject("Characters").transform;
            }
            Vector2Int vector2Int;
            foreach (PluggableCharacterData characterData in gameSettings.debugCharactersToSpawn)
            {
                vector2Int = new Vector2Int(Random.Range(-gameSettings.charactersRandomSpread.x, gameSettings.charactersRandomSpread.x), Random.Range(-gameSettings.charactersRandomSpread.y, gameSettings.charactersRandomSpread.y));
                GameObject instance = spawnerHelper.SpawnCharacter(characterData, charactersTransform.gameObject.transform, new Vector3(vector2Int.x, 0, vector2Int.y), Quaternion.identity);

                //  (characterData as ICreateInstance).CreateInstance(charactersTransform.gameObject.transform, new Vector3(vector2Int.x, 0, vector2Int.y), Quaternion.identity);


            }

        }

        public void InitSpawner()
        {
            if (spawnerHelper == null)
            {

                spawnerHelper = new GameObject("spawnerHelper").AddComponent<SpawnerHelper>();
                spawnerHelper.gameObject.transform.parent = gameObject.transform;
                spawnerHelper.Init();
            }


        }

        private void InitializeBuildSystem()
        {
            bool b = gameSettings.scriptableBuildSystem != null;
            b = b && gameSettings.scriptableBuildSystem.initializeOnStart;
            if (b)
            {
                GameObject systemGO = new GameObject();
                systemGO.transform.parent = this.transform;
                gameSettings.scriptableBuildSystem.Initialize(systemGO);

            }

        }

        private void InitializeDataSystem()
        {
            if (gameSettings.scriptableDataSystem != null && gameSettings.scriptableDataSystem.initializeOnStart)
            {
                GameObject systemGO = new GameObject();
                systemGO.transform.parent = this.transform;
                gameSettings.scriptableDataSystem.Initialize(systemGO);

            }

        }

        private void InitializeSelectSystem()
        {
            if (gameSettings.scriptableSelectSystem != null && gameSettings.scriptableSelectSystem.initializeOnStart)
            {
                GameObject systemGO = new GameObject();
                systemGO.transform.parent = this.transform;
                gameSettings.scriptableSelectSystem.Initialize(systemGO);

            }

        }

        public void Quit()
        {
            //dataSystemMonoBehaviour.SaveObjects();
            // dataSystemMonoBehaviour.SavePlayerData();
            Application.Quit();
        }
        public void DeleteSave()
        {
            dataSystemMonoBehaviour.DeleteSavedObjects();

        }



    }
}
