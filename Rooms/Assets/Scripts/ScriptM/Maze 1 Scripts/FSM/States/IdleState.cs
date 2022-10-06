    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    //Enemy States
    public PatrolState patrolState;
    public ChaseState chaseState;
    public RunState runState;

    public Animator MonsterAnimation;

    public GameObject enemy;
    public NavMeshAgent agent;


    float startTime = 0f;
    float waitFor = 2f;
    bool timerStart = false;


    public bool doneWaitingWayPoint;
    public bool inRange;
    public bool glassSharpAnimation;

    public void Awake()
    {
        doneWaitingWayPoint = false;
        inRange = false;
        glassSharpAnimation = false;

    }


    public void Update()
    {
  /*      if (timerStart && Time.time - startTime > waitFor)
        {
            doneWaitingWayPoint = true;
            timerStart = false;
        }*/
    }

    public override State RunCurrentState()
    {


        agent.speed = 0f;
        IdleAnimation();
        inRange = FindObjectOfType<CheckIfInRange>().GetPlayerIfIn();
        StartCoroutine(WaitThenGo());


        if (inRange)
        {
            return chaseState;
        }
        else if (doneWaitingWayPoint)
        {
            Debug.Log("Done" );
            return patrolState;
        }
        else if (glassSharpAnimation)
        {
            return runState;
        }
        else
        {
            return this;
        }

    


    }

    IEnumerator WaitThenGo()
    {
        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2);

        doneWaitingWayPoint = true;


    }


    void IdleAnimation()
    {
        MonsterAnimation.SetBool("EnemyWalk", false);
        MonsterAnimation.SetBool("EnemyAttack", false);
        MonsterAnimation.SetBool("EnemyIdle", true);
        MonsterAnimation.SetBool("EnemyRun", false);
        MonsterAnimation.SetFloat("Speed", 0f);

    }

}
