using EditorTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{

    [CreateAssetMenu(fileName = "BuildObjectMaterialSet", menuName = "ScriptableSystems/Build System/Build Object Material Set")]

    public class BuildObjectMaterialSet : ScriptableObject
    {
        public string id;

        [ConfigSelector(paramsSetKey = "MaterialType")]
        public string materialType;

        [ConfigSelector(paramsSetKey = "ObjectType")]
        public string objectType;

        public List<Material> availableMaterials;
    }

}