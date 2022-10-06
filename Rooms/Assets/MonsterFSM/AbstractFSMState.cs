using Assets.MonsterFSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum ExecutionState
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public enum FSMStateType
{
    IDLE,
    PATROL,
};


public abstract class AbstractFSMState : ScriptableObject
{
    /*                     ExecutionState _executionState;
     *                     
     *                     public ExecutionState ExecutionState 
     *               {
     *                  get
     *                  {
     *                      return _executionState;
     *                  } 
     *                  
     *                  protected set
     *                  {
     *                      _executionState = value;
                         }

     */

    protected NavMeshAgent _navMeshAgent;
    protected Monster _monster;
    protected FiniteStateMachine _fsm;

    public ExecutionState ExecutionState { get; protected set; }
    public FSMStateType StateType { get; protected set; }
    public bool EnteredState { get; protected set; }

    public virtual void OnEnable()
    {
        ExecutionState = ExecutionState.NONE;
    }

    public virtual bool EnterState()
    {
        Debug.Log("EnterState()");
        bool successNavMesh = true;
        bool successsMonster = true;

        ExecutionState = ExecutionState.ACTIVE;
        // does the Nav mesh agent exist?
        successNavMesh = (_navMeshAgent != null);

        // does the Executing agent exist?
        successsMonster = (_monster != null);

        return successNavMesh & successsMonster;
    }

    public abstract void UpdateState();
    

    public virtual bool ExitState()
    {
        ExecutionState = ExecutionState.COMPLETED;
        return true;
    }

    public virtual void SetNavMeshAgent(NavMeshAgent navmeshAgent)
    {
        if(navmeshAgent != null)
        {
            _navMeshAgent = navmeshAgent;
        }
    }

    public virtual void SetExecutingFSM(FiniteStateMachine fsm)
    {
        if(fsm != null)
        {
            _fsm = fsm;
        }
    }

    public virtual void SetExecutingMonster(Monster monster)
    {
        if(monster != null)
        {
            _monster = monster;
        }
    }

}
