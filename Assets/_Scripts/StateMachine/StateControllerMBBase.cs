
using UnityEngine;

namespace Assets._Scripts.StateMachine
{
    public class StateControllerMBBase : MonoBehaviour
    {
        public float stateTimeElapsed;
        public State currentState;
        public State remainState;
        public bool isActive;
        [Range(0, 20)]
        public int interval = 0;
        private int counter = 0;

        public void Setup(bool _isActive)
        {

            isActive = _isActive;

        }

        void Update()
        {

            if (counter < interval)
            {

                counter++;

                return;
            }
            else
            {
                counter = 0;

            }
            if (!isActive)
                return;


            currentState.UpdateState(this);
        }
        public void TransitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
                OnExitState();
            }
        }

        void OnDrawGizmos()
        {
            if (currentState != null)
            {
                Gizmos.color = currentState.sceneGizmoColor;
                Gizmos.DrawWireSphere(transform.position, 1.5f);
            }
        }

        public bool CheckIfCountDownElapsed(float duration)
        {
            stateTimeElapsed += Time.deltaTime;
            return (stateTimeElapsed >= duration);
        }

        private void OnExitState()
        {
            stateTimeElapsed = 0;
        }
    }
}