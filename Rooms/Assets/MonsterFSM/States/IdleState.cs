using UnityEditor;
using UnityEngine;

namespace Assets.MonsterFSM.States
{
    [CreateAssetMenu(fileName = "IdleState", menuName ="Rooms/States/Idle", order = 1)]

    public class IdleState : AbstractFSMState
    {

        [SerializeField] float _idleDuration = 3f;

        float _totalDuration;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.IDLE;
        }

        public override bool EnterState()
        {
            EnteredState =  base.EnterState();
            if (EnteredState)
            {
                Debug.Log("IDLE State Enetered");
                _totalDuration = 0f;

            }
            return EnteredState;
        }

        public override void UpdateState()
        {
            if (EnteredState)
            {
                _totalDuration += Time.deltaTime;

                Debug.Log("Updating IDLE State"+_totalDuration+"Seconds");

                if(_totalDuration >= _idleDuration)
                {
                    _fsm.EnterState(FSMStateType.PATROL);
                }

            }
        }

        public override bool ExitState()
        {
             base.ExitState();
            Debug.Log("IDLE State Exiting");
            return true;
        }

    }
}