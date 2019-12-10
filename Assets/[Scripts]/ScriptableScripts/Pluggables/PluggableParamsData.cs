using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EditorTools
{
    [CreateAssetMenu(fileName = "PluggableParams", menuName = "Characters/PluggableParams")]
    public class PluggableParamsData : ScriptableObject
    {
      // public PluggableParams pluggableParams;

        public List<ParameterBase> dynamicParameters = new List<ParameterBase>();
        public List<ParameterBase> staticParameters = new List<ParameterBase>();

        public int GetIndexOfDynamic(string _id)
        {
            int i = -1;
            // dynamicParameters.IndexOf
            ParameterBase par = dynamicParameters.FirstOrDefault(x => x.id == _id);
            if(par!=null)
            {
                i = dynamicParameters.IndexOf(par);

            }

            return i;

        }
        
    }

    [Serializable]
    public class PluggableParams 
    {

        public List<ParameterBase> dynamicParameters = new List<ParameterBase>();
        public List<ParameterBase> staticParameters = new List<ParameterBase>();

        public int GetIndexOfDynamic(string _id)
        {
            int i = -1;
            // dynamicParameters.IndexOf
            ParameterBase par = dynamicParameters.FirstOrDefault(x => x.id == _id);
            if (par != null)
            {
                i = dynamicParameters.IndexOf(par);

            }

            return i;

        }

        public int GetIndexOfStatic(string _id)
        {
            int i = -1;
            ParameterBase par = staticParameters.FirstOrDefault(x => x.id == _id);
            if (par != null)
            {
                i = staticParameters.IndexOf(par);

            }

            return i;

        }

    }
}