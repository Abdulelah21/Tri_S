using System.Collections;
using UnityEngine;

namespace Assets.MonsterFSM.States
{
    [CreateAssetMenu(fileName = "PatrolState", menuName = "Rooms/States/Patrol",order =2)]
    public class PatrolState : AbstractFSMState
    {
        MonsterControlPoint[] _patrolPoints;
        int _patrolPointIndex;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.PATROL;
            _patrolPointIndex = -1;
        }

        public override bool EnterState()
        {
            EnteredState = false;
            if (base.EnterState())
            {
                // Grab and Stroe Patrol Points.
                _patrolPoints = _monster.PatrolPoints;

                if (_patrolPoints == null || _patrolPoints.Length == 0)
                {
                    Debug.LogError("PatrolState: Failed to  grab patrol points from the monster");
                    return false;
                }
                else
                {
                    if (_patrolPointIndex < 0)
                    {
                        _patrolPointIndex = UnityEngine.Random.Range(0, _patrolPoints.Length);
                    }
                    else
                    {
                        _patrolPointIndex = (_patrolPointIndex + 1) % _patrolPoints.Length;
                    }

                    SetDestination(_patrolPoints[_patrolPointIndex]);
                    EnteredState = true;
                }
            }
            return EnteredState;
        } 

        public override void UpdateState()
        {

            //TO DO: Need to make sure we successfully entered the state. 
            if (EnteredState)
            {
                if (Vector3.Distance(_navMeshAgent.transform.position, _patrolPoints[_patrolPointIndex].transform.position) <= 1f)
                {
                    _fsm.EnterState(FSMStateType.IDLE);
                }
            }

        }

        private void SetDestination(MonsterControlPoint destination)
        {
            if(_navMeshAgent != null && destination != null)
            {
                _navMeshAgent.SetDestination(destination.transform.position);
            }
        }

    }
}