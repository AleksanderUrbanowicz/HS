using EditorTools;
using ScriptableSystems;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public int cash;
        public BuildSystemMonoBehaviour buildSystemMonoBehaviour;
        public DataSystemMonoBehaviour dataSystemMonoBehaviour;
        public RaycastExecutor raycastExecutor;
        public SpawnerHelper spawnerHelper;
        public GameSettings settings;
        public Text infoText;
        [SerializeField]
        public static GameSettings s;
        public static GameManager instance;
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (GameManager.instance == null)
            {
                GameManager.instance = this;
            }

            if (GameManager.s == null)
            {
                GameManager.s = settings;
            }
        }

        private void Start()
        {
            InitializeBuildSystem();
            InitializeDataSystem();
            InitializeSelectSystem();
        }

        void Update()
        {
            if (infoText != null)
            {

                infoText.text = "Cash: " + cash.ToString();
            }
        }

        private void InitializeBuildSystem()
        {
            bool b = s.scriptableBuildSystem != null;
            b = b && s.scriptableBuildSystem.initializeOnStart;
            // if (s.scriptableBuildSystem != null && s.scriptableBuildSystem.initializeOnStart)
            if (b)
            {
                GameObject systemGO = new GameObject();
                systemGO.transform.parent = this.transform;
                s.scriptableBuildSystem.Initialize(systemGO);

            }

        }

        private void InitializeDataSystem()
        {
            if (s.scriptableDataSystem != null && s.scriptableDataSystem.initializeOnStart)
            {
                GameObject systemGO = new GameObject();
                systemGO.transform.parent = this.transform;
                s.scriptableDataSystem.Initialize(systemGO);

            }

        }

        private void InitializeSelectSystem()
        {
            if (s.scriptableSelectSystem != null && s.scriptableSelectSystem.initializeOnStart)
            {
                GameObject systemGO = new GameObject();
                systemGO.transform.parent = this.transform;
                s.scriptableSelectSystem.Initialize(systemGO);

            }

        }

        public void Quit()
        {
            dataSystemMonoBehaviour.SaveObjects();
            dataSystemMonoBehaviour.SavePlayerData();
            Application.Quit();
        }
    }
}