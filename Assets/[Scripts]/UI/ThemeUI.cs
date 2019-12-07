using UnityEngine;

namespace ScriptableSystems
{
    [ExecuteInEditMode]
    public class ThemeUI : MonoBehaviour
    {

        public ThemeUIData themeData;
        protected virtual void OnThemeDraw()
        {


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