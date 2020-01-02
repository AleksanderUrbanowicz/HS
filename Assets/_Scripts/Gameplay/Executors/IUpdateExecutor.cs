﻿

namespace Assets._Scripts.Gameplay.Executors
{
    public interface IUpdateExecutor : IExecutor//, IConditionalExecutor
    {
        void StartExecute();
        void StopExecute();



        bool CheckUpdateConditions { get; }
        bool CheckPreConditions { get; }
    }
}