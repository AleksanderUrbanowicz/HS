using BaseLibrary.Interfaces;
using Data;
using System.Collections.Generic;
using UnityEngine;
namespace UI
{
    public class UIBuildObjectPopulator<T> : IUISpawner where T : ISpawnable
    {

        public List<BuildObjectData> items=new List<BuildObjectData>();
        public GameObject prefab;
        public RectTransform parentTransform;
        public void Init(BuildObjectData[] _spawnables, RectTransform _parent,GameObject _prefab)
        {
            prefab = _prefab;
            parentTransform = _parent;
            foreach (BuildObjectData ui in _spawnables)
            {

                RegisterUI(ui);
            }

        }
      

        public void RegisterUI(BuildObjectData _spawnableUIData)
        {
            items.Add(_spawnableUIData);
            InstantiateUI(_spawnableUIData);
        }

        public void InstantiateUI(List<BuildObjectData> _spawnableUI)
        {
            foreach(BuildObjectData spawnable in _spawnableUI)
            {
                InstantiateUI(spawnable);

            }
        }
        public GameObject InstantiateUI(BuildObjectData _spawnableUI)
        {
            Debug.Log("InstantiateUI with id: " + (_spawnableUI as ISpawnable).GetID + ".");

            GameObject instance = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity, parentTransform);
            instance.name = (_spawnableUI as ISpawnable).GetID;
            instance.transform.localPosition = Vector3.zero;
            instance.GetComponentInChildren<BuildObjectUI>().Init(_spawnableUI);
            instance.SetActive(true);
            return instance;


        }
        public void ToggleVisibility(string _id, bool b)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterUI(ISpawnable _spawnableUIData)
        {
            RegisterUI(_spawnableUIData as BuildObjectData);
        }

        public GameObject InstantiateUI(ISpawnable _spawnableUI)
        {
           return InstantiateUI(_spawnableUI as BuildObjectData);
             }
    }
}