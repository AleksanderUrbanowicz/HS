using EditorTools;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "EmployeeData", menuName = "Characters/Employee Data")]

    public class EmployeeData : CharacterDataBase
    {

        [ConfigSelector(paramsSetKey = StringDefines.EmployeeTypeSelectorKey)]

        public string employeeType;
        public EmployeeTypeData employeeTypeData;
        public float salary;
        [RangeAttribute(0.0f,100.0f)]
        public float skill;
        [RangeAttribute(0.0f, 10.0f)]
        public float speed;

        List<ParameterBase>  GetAccumulatedDynamicParameters()
        {
            List<ParameterBase> accumulatedParams = base.dynamicParameters;
            foreach (ParameterBase par in employeeTypeData.dynamicEmployeeTypeModifiers)
            {
                if (accumulatedParams.Contains(par))
                {
                    accumulatedParams[accumulatedParams.IndexOf(par)].value += par.value;
                }
                else
                {
                    accumulatedParams.Add(par);

                }

            }
            return accumulatedParams;
        }

         List<ParameterBase> GetAccumulatedStaticParameters()
        {

            List<ParameterBase> accumulatedParams = base.staticParameters;
            foreach (ParameterBase par in employeeTypeData.staticEmployeeTypeModifiers)
            {
                if (accumulatedParams.Contains(par))
                {
                    accumulatedParams[accumulatedParams.IndexOf(par)].value += par.value;
                }
                else
                {
                    accumulatedParams.Add(par);

                }

            }
            return accumulatedParams;
        }

        public EmployeeData()
        {
            base.characterType = "Employee";
        }

    }
}