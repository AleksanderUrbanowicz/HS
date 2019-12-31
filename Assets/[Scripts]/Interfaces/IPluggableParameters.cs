using EditorTools;

namespace Interfaces
{
    public interface IPluggableParameters
    {

        PluggableParams GetAccumulatedParameters();

        void AddIndividualParameters();

    }
}