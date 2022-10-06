using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.MonsterFSM
{
    public class FiniteStateMachine : MonoBehaviour
    {
        
        AbstractFSMState _currentState;


        [SerializeField] List<AbstractFSMState> _validStates;
        Dictionary<FSMStateType, AbstractFSMState> _fsmState;

        public void Awake()
        {
            _currentState = null;

            _fsmState = new Dictionary<FSMStateType, AbstractFSMState>();

            NavMeshAgent navMeshAgent = this.GetComponent<NavMeshAgent>();
            Monster monster = this.GetComponent<Monster>();

            foreach(AbstractFSMState state in _validStates)
            {
                state.SetExecutingFSM(this);
                state.SetExecutingMonster(monster);
                state.SetNavMeshAgent(navMeshAgent);
            }

        }

        public void Start()
        {
            EnterState(FSMStateType.IDLE);
        }

        public void Update()
        {
            if(_currentState != null)
            {
                _currentState.UpdateState();
            }
        }

        #region STATE MANAGEMENT

        public void EnterState(AbstractFSMState nextState)
        {
            Debug.Log("EnterState()");

            if (nextState == null)
            {
                return;
            }
            if (_currentState != null)
            {
                _currentState.ExitState();
            }
            _currentState = nextState;
            _currentState.EnterState();

        }

        public void EnterState(FSMStateType stateType)
        {
            if (_fsmState.ContainsKey(stateType))
            {
                AbstractFSMState nextState = _fsmState[stateType];
                EnterState(nextState);
            }
        }

        #endregion


    }
}