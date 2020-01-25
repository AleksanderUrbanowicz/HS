using BaseLibrary.Interfaces;

namespace Data
{
    public interface ISpawnableBuildObject : ISpawnable
    {

        BuildObjectData BuildObjectData { get; }
        // ScriptableObject GetScriptableObject { get; }
    }
}