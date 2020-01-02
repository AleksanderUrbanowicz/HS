using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Data.Containers
{
    // [CreateAssetMenu(fileName = "ScriptableRuntimeCollection", menuName = "Collections/Runtime Collection")]
    public abstract class RuntimeCollection<T> : ScriptableObject
    {
        public List<T> Items = new List<T>();

        public void Add(T t)
        {
            if (!Items.Contains(t))
            {
                Items.Add(t);

            }
            else
            {

                Debug.Log("RuntimeCollection<" + typeof(T) + "> already has item: " + t.ToString());
            }

        }
        public void Remove(T t)
        {
            if (Items.Contains(t))
            {
                Items.Remove(t);

            }
            else
            {

                Debug.Log("RuntimeCollection<" + typeof(T) + "> does not have item: " + t.ToString());

            }

        }
    }


}