namespace BaseLibrary.Interfaces
{
    public interface IUpdateExecutor : IExecutor
    {
        void StartExecute();
        void StopExecute();

        bool IsExecuting { get; }
        bool CheckUpdateConditions { get; }
        bool CheckPreConditions { get; }
    }
}