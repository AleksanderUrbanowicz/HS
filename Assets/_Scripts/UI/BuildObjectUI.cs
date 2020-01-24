using BaseLibrary.Data;
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class BuildObjectUI : MonoBehaviour
    {
        public Image image;
        public Text text;
        public BuildObjectData buildObjectData;

        public void Init(BuildObjectData _spawnable)
        {

            this.buildObjectData = _spawnable;
            Image.sprite = buildObjectData.renderSprite;
            Text.text = buildObjectData.id+" :  "+buildObjectData.cost;
        }

        public Image Image
        {
            get
            {
                if (image == null)
                {
                    image = GetComponent<Image>();
                }
                return image;
            }
            set => image = value;
        }

        public Text Text { get {
                if(text==null)
                {
                    text=GetComponentInChildren<Text>();
                    if (text == null)
                    {
                        text = new GameObject("BuildObjectText", typeof(Text)).GetComponent<Text>();
                    }
                    text.transform.parent = transform;
                }
                return text; } set => text = value; }
    }
}