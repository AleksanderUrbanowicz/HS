using Characters;
using EditorTools;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableSystems
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

        public Text infoText;
        public static int cash;
        public List<PluggableCharacterData> charactersToSpawn = new List<PluggableCharacterData>();
        public Transform charactersTransform;
        public Transform systemsTansform;
        public List<Transform> patrolWaypoints = new List<Transform>();
        public List<Transform> interactablePoints = new List<Transform>();
        public List<ScriptableSystem> scriptableSystems = new List<ScriptableSystem>();
        public List<PluggableMonoBehaviour> pluggablesInScene = new List<PluggableMonoBehaviour>();

        public PluggableRuntimeCollection Set;

        public Text Text;

        private int previousCount = -1;

        private void OnEnable()
        {
            UpdateText();
        }

        private void Update()
        {
            if (previousCount != Set.Items.Count)
            {
                UpdateText();
                previousCount = Set.Items.Count;
            }
        }

        public void UpdateText()
        {
            if (Text != null)
            {
                Text.text = "There are " + Set.Items.Count + " things.";
            }
        }
        public Vector2Int charactersRandomSpread;

        void Start()
        {

            if (charactersRandomSpread == null || charactersRandomSpread == Vector2Int.zero)
            {
                charactersRandomSpread = Vector2Int.one;

            }
            if (systemsTansform == null)
            {
                systemsTansform = new GameObject("SystemsTansform").transform;
            }
            foreach (ScriptableSystem scriptableSystem in scriptableSystems)
            {

                if (scriptableSystem.initializeOnStart)
                {
                    GameObject systemGO = new GameObject();
                    systemGO.transform.parent = systemsTansform;
                    scriptableSystem.Initialize(systemGO);
                }

            }

            if (charactersRandomSpread == null || charactersRandomSpread == Vector2Int.zero)
            {
                charactersRandomSpread = Vector2Int.one;

            }

            if (charactersTransform == null)
            {
                charactersTransform = new GameObject("Characters").transform;
            }
            Vector2Int vector2Int;
            foreach (PluggableCharacterData characterData in charactersToSpawn)
            {
                vector2Int = new Vector2Int(Random.Range(-charactersRandomSpread.x, charactersRandomSpread.x), Random.Range(-charactersRandomSpread.y, charactersRandomSpread.y));


                GameObject characterGO = new GameObject();
                characterGO.transform.parent = charactersTransform;
                GameObject instance = characterData.CreateInstance(characterGO, new Vector3(vector2Int.x, 0, vector2Int.y));
                // instance.transform.localPosition=new Vector3(charactersRandomSpread.x, 0 ,  charactersRandomSpread.y);


            }

        }



    }
}
