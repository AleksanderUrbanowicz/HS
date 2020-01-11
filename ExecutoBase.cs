using BaseLibrary.Managers;
using BaseLibrary.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers
{
    public abstract class ExecutoBase : IUpdateExecutor
    {
        protected int updateCounter;
        public int executeInterval;
        private bool isExecuting;
        public bool boolOutput;
        protected BoolEventListener hitMissListeners;

        public virtual void Update()
        {

            if (!CheckPreConditions)
            {
                return;
            }


            if (CheckUpdateConditions)
            {
                //Debug.Log("CheckUpdateConditions true");
                Execute();

            }

        }

        public virtual void StartExecute()
        {
            IsExecuting = true;
        }

        public virtual void StopExecute()
        {
            IsExecuting = false;
        }

        public void SendEvent()
        {

            boolOutput = !boolOutput;
            if (boolOutput)
            {
                if (raycastdata.stopAfterHit)
                {
                    (this as IUpdateExecutor).StopExecute();

                }
                raycastdata.hitMissEvents.scriptableEventTrue.Raise();
            }
            else
            {
                raycastdata.hitMissEvents.scriptableEventFalse.Raise();
            }
        }

        bool CheckUpdateConditions
        {
            get
            {
                if (executeInterval == 0)
                {
                    return true;

                }

                updateCounter++;
                if (updateCounter > executeInterval)
                {

                    updateCounter = 0;
                    return true;
                }
                return false;
            }
        }
        public bool CheckPreConditions
        {
            get
            {
                return IsExecuting;
            }
        }

        public bool IsExecuting => isExecuting;

    }
}