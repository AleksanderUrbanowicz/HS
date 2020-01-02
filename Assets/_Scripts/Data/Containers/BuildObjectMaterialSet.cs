using Assets._Scripts.Data.Definitions;
using Assets._Scripts.EditorUtilities;
using System.Collections.Generic;
using UnityEngine;
namespace Assets._Scripts.Data.Containers
{

    [CreateAssetMenu(fileName = "BuildObjectMaterialSet", menuName = "ScriptableSystems/Build System/Build Object Material Set")]

    public class BuildObjectMaterialSet : ScriptableObject
    {
        public string id;

        [ConfigSelector(ParamsSetKey = StringDefines.MaterialTypeSelectorKey)]
        public string materialType;

        [ConfigSelector(ParamsSetKey = StringDefines.ObjectTypeSelectorKey)]

        public string objectType;

        public List<Material> availableMaterials;
    }

}