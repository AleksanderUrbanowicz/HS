using Definitions;
using UnityEngine;

namespace UI
{
    [ExecuteInEditMode]
    public class ThemeUI : MonoBehaviour
    {

        public ThemeUIData themeData;
        public ControlSize controlSize;
        public RectTransform controlRect;
        //public float relativeWidth=1.0f;
        public Vector2 relativeSize = Vector2.one;
       
        protected virtual void OnThemeDraw()
        {
            /*
            if(!controlRect)
            {

                controlRect = GetComponent<RectTransform>();
            }
            if(controlSize==0)
            {
                controlSize = themeData.defaultSliderSize;

            }
            controlRect.sizeDelta = themeData.defaultSliderSize * relativeSize;
            
            /*switch (controlSize)
            {
                case ControlSize.DEFAULT:
                    {


                        break;
                    }
                case ControlSize.SMALL:
                    {
                        controlRect.sizeDelta = themeData.smallControlSize * relativeSize;

                        break;
                    }
                case ControlSize.MEDIUM:
                    {

                        controlRect.sizeDelta = themeData.mediumControlSize * relativeSize; ;

                        break;
                    }
                case ControlSize.LARGE:
                    {

                        controlRect.sizeDelta = themeData.largeControlSize * relativeSize; ;

                        break;
                    }
                case ControlSize.HUGE:
                    {

                        controlRect.sizeDelta = themeData.hugeControlSize * relativeSize; ;

                        break;
                    }


            }
            */

        }

        public virtual void Awake()
        {

            OnThemeDraw();
        }
        public virtual void Update()
        {

            if (Application.isEditor)
            {

                OnThemeDraw();
            }
        }
    }
}