namespace Data
{
    public interface IPluggableParameters
    {

        PluggableParams GetAccumulatedParameters();

        void AddIndividualParameters();

    }
}