using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorTools
{
    public class ScriptableCollections
    {
/*
        public abstract class BaseCollection : SOArchitectureBaseObject, IEnumerable
        {
            public object this[int index]
            {
                get
                {
                    return List[index];
                }
                set
                {
                    List[index] = value;
                }
            }

            public int Count { get { return List.Count; } }

            public abstract IList List { get; }
            public abstract Type Type { get; }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return List.GetEnumerator();
            }
            public bool Contains(object obj)
            {
                return List.Contains(obj);
            }
        }


        public abstract class SOArchitectureBaseObject : ScriptableObject
        {
#pragma warning disable 0414
            [SerializeField]
            private DeveloperDescription DeveloperDescription = new DeveloperDescription();
#pragma warning restore
        }


        [Serializable]
        public class DeveloperDescription : IEquatable<DeveloperDescription>, IEquatable<string>
        {
            public DeveloperDescription() { }
            public DeveloperDescription(string value)
            {
                _value = value;
            }

            [SerializeField]
            private string _value = string.Empty;

            public static implicit operator string(DeveloperDescription description)
            {
                return description._value;
            }
            public static implicit operator DeveloperDescription(string value)
            {
                return new DeveloperDescription(value);
            }

            public override bool Equals(object obj)
            {
                return _value.Equals(obj);
            }
            public bool Equals(DeveloperDescription other)
            {
                if (other == null)
                    return false;

                return _value == other._value;
            }
            public bool Equals(string other)
            {
                if (other == null)
                    return false;

                return _value == other;
            }
            public override int GetHashCode()
            {
                return _value.GetHashCode();
            }
            public override string ToString()
            {
                return _value;
            }
        }


        public class Collection<T> : BaseCollection, IEnumerable<T>
        {
            public new T this[int index]
            {
                get
                {
                    return _list[index];
                }
                set
                {
                    _list[index] = value;
                }
            }

            [SerializeField]
            private List<T> _list = new List<T>();

            public override IList List
            {
                get
                {
                    return _list;
                }
            }
            public override Type Type
            {
                get
                {
                    return typeof(T);
                }
            }

            public void Add(T obj)
            {
                if (!_list.Contains(obj))
                    _list.Add(obj);
            }
            public void Remove(T obj)
            {
                if (_list.Contains(obj))
                    _list.Remove(obj);
            }
            public void Clear()
            {
                _list.Clear();
            }
            public bool Contains(T value)
            {
                return _list.Contains(value);
            }
            public int IndexOf(T value)
            {
                return _list.IndexOf(value);
            }
            public void RemoveAt(int index)
            {
                _list.RemoveAt(index);
            }
            public void Insert(int index, T value)
            {
                _list.Insert(index, value);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public IEnumerator<T> GetEnumerator()
            {
                return _list.GetEnumerator();
            }
            public override string ToString()
            {
                return "Collection<" + typeof(T) + ">(" + Count + ")";
            }
            public T[] ToArray()
            {
                return _list.ToArray();
            }
        }
*/
    }
}