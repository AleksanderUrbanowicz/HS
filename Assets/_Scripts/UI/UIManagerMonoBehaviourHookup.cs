using BaseLibrary.BaseAndAbstracts;

using BaseLibrary.DataContainers;
using BaseLibrary.Implementations;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Managers
{
    public class UIManagerMonoBehaviourHookup : MonoBehaviourHookup
    {
        public Canvas UICanvas;
        private UISpawner spawner;

        public UISpawner Spawner { get => spawner; set => spawner = value; }

        public void InitSpawner(List<SpawnableUIData> _spawnableUIs)
        {
            Spawner = gameObject.GetComponent<UISpawner>() != null ? gameObject.GetComponent<UISpawner>() : gameObject.gameObject.AddComponent<UISpawner>();

            UICanvas = new GameObject("UICanvas",typeof( Canvas)).GetComponent<Canvas>();
            UICanvas.transform.parent = spawner.transform;
            InitCanvas();
           // Spawner = gameObject.AddComponent<UISpawner>();
            Spawner.Init( _spawnableUIs, UICanvas.transform);
        }

        public void InitCanvas()
        {
            CanvasData canvasData = SingletonUIManager.Instance.CanvasData;
            if(canvasData==null)
            {
                return;

            }
            UICanvas.worldCamera = GameObject.FindGameObjectWithTag(canvasData.UICameraTag).GetComponent<Camera>();
            UICanvas.renderMode = canvasData.renderMode;
            
        }
      
       
    }
}