using BaseLibrary.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewBuildObjectData", menuName = "ScriptableSystems/Build System/Build Object Data")]
    public class BuildObjectData : ScriptableObject, ISpawnableBuildObject
    {

        public string id;

        public GameObject objectPrefab;
        public Vector3 offset;
        public Vector3 actualSize;
        public Vector3 gridSize;
        public Vector3 orientationVector = Vector3.up;
        public Sprite renderSprite;
        public RenderTexture renderTexture;

        //private Dictionary<string, Vector3> sizes;

        public int cost;
        //public ObjectOrientation objectOrientation = ObjectOrientation.FLOOR;

        public LayerMask layersToBuildOn;
        public LayerMask obstacleLayers;

        public float collsionBoundsFraction = 0.95f;
        public float rotationStep = 90.0f;

        public List<BuildObjectMaterialData> materialData;

        public PluggableDynamicParams pluggableDynamicParams;

        void OnEnable()

        {
            if(renderSprite==null && renderTexture!=null)
            {

                //Texture2D myTexture = toTexture2D(renderTexture);
               // Texture2D texture2D;// = new Texture2D(320, 240);
               // texture2D = toTexture2D(renderTexture);
               // renderSprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            }

        }

        GameObject ISpawnable.GetPrefab
        {
            get
            {
                return objectPrefab;
            }
        }

        string ISpawnable.GetID
        {
            get
            {
                return id;
            }
        }

        Texture2D toTexture2D(RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(512, 512, TextureFormat.RGB24, false);
            RenderTexture.active = rTex;
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();
            return tex;
        }


        public ScriptableObject GetScriptableObject => this as ScriptableObject;


        BuildObjectData ISpawnableBuildObject.BuildObjectData => this;
    }
}
