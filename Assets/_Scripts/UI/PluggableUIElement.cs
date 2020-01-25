using BaseLibrary.Interfaces;

using Managers;
using UnityEngine;

namespace UI
{
    [ExecuteInEditMode]
    public class PluggableUIElement : MonoBehaviour, IPlugginableUI
    {
        public PluggableUIData themeData;
        public PluggableUIData ThemeData
        {
            get
            {

#if UNITY_EDITOR
                return themeData != null ? themeData : SingletonUIManager.EditorInstance.PluggableUIData;
#else
                return themeData != null ? themeData : SingletonUIManager.Instance.PluggableUIData;

#endif
                // return themeData != null ? themeData : SingletonUIManager.Instance.PluggableUIData;
                // return themeData;

            }


        }

        protected virtual void OnThemeDraw()
        {


        }

        public virtual void Awake()
        {
            // themeData = ThemeData;
            OnThemeDraw();
        }
        public virtual void Update()
        {

            if (Application.isEditor)
            {

                OnThemeDraw();
            }
        }

        public PluggableUIData GetPluggableUIData(IPluggableUI pluggableUI)
        {
            throw new System.NotImplementedException();
        }

        public void PlugData(IPluggableUI pluggableUI, PluggableUIData themeData)
        {
            throw new System.NotImplementedException();
        }
    }
}