using Gameplay;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ScriptableSystems
{
    // Class: ScriptableSystemManager
    //  MonoBehaviour script for managing scriptable systems of different levels
    public class ScriptableSystemManager : MonoBehaviour
    {

        public Text infoText;
        public static int cash;
        public List<ScriptableSystem> scriptableSystems = new List<ScriptableSystem>();
        // public List<ScriptableExecutor> scriptableTools = new List<ScriptableExecutor>();
        void Start()
        {
            foreach (ScriptableSystem scriptableSystem in scriptableSystems)
            {

                if (scriptableSystem.initializeOnStart)
                {
                    GameObject systemGO = new GameObject();
                    systemGO.transform.parent = this.transform;
                    scriptableSystem.Initialize(systemGO);
                }

            }

        }

        // Update is called once per frame
        void Update()
        {
            if (infoText != null)
            {

                infoText.text = GameManager.instance.cash.ToString();
            }
        }
    }
}
