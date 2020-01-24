
using GeneralImplementations.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PluggableParams_", menuName = "Data/PluggableParams")]
    public class PluggableParamsData : ScriptableObject
    {

        public List<ParameterBase> activeParameters = new List<ParameterBase>();

    }

    [Serializable]
    public class PluggableDynamicParams
    {

        public List<DynamicParameter> parameters = new List<DynamicParameter>();


        public PluggableDynamicParams(List<DynamicParameter> _parameters)
        {
            parameters = _parameters;


        }

       

        public PluggableParams ToPluggableParams()
        {
            PluggableParams parameters = new PluggableParams();
            foreach (DynamicParameter par in this.parameters)
            {
                parameters.parameters.Add(par as ParameterBase);

            }


            return parameters;
        }
       
    }
    [Serializable]
    public class PluggableParams
    {

        public List<ParameterBase> parameters = new List<ParameterBase>();

        


        public PluggableParams()
        {


        }




        public int GetIndexOfActive(string _id)
        {
            //int i = -1;

            ParameterBase par = parameters.FirstOrDefault(x => x.id == _id);
            if (par != null)
            {
                int i = parameters.IndexOf(par);
                return i;
            }

            return -1;

        }



        public PluggableParams GetParams(List<string> _ids)
        {
            PluggableParams selected = new PluggableParams();
            int index;
            foreach (string s in _ids)
            {
                index = GetIndexOfActive(s);
                if (index != -1)
                {

                    selected.parameters.Add(new ParameterBase(parameters[index].id, parameters[index].value));
                }

            }
            return selected;
        }
       

        public void Add(ParameterBase parameterBase)
        {
            foreach (ParameterBase par in parameters)
            {
                if (par.id == parameterBase.id)
                {
                    par.value += parameterBase.value;

                }


            }

        }

        public ParameterBase Get(string _id)
        {
            foreach (ParameterBase par in parameters)
            {
                if (par.id == _id)
                {
                    return par;

                }

            }
            return null;

        }
    }
}