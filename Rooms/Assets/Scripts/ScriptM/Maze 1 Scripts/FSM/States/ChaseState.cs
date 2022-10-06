using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
   public AttackState attackState;
   public PatrolState patrolState;


    public bool inAttackRange = false;
    public bool inRange;
    public Transform target;
    public float minimumDistance;
    public GameObject player;
    public GameObject enemy;
    public NavMeshAgent agent;
    public Animator MonsterAnimation;

   
    public override State RunCurrentState()
    {

        inRange = FindObjectOfType<CheckIfInRange>().GetPlayerIfIn();

        if (inRange)
        {
            ChasePlayerAnimation();
            agent.speed = 5f;
            agent.SetDestination(player.transform.position);
            if (Vector3.Distance(enemy.transform.position , target.position)< minimumDistance)
            {
                inAttackRange = true;
            }
        }        

            if (inAttackRange && inRange)
        {
            return attackState;
        }
        else if (!inRange)
        {
            return patrolState;
        }
        else
        {
            return this;
        }
    }
    public bool GetInAttackRange()
    {
        return inAttackRange;
    }

    public void SetInAttackRange(bool _inAttackRange)
    {
        inAttackRange = _inAttackRange;
    }

    void ChasePlayerAnimation()
    {
        MonsterAnimation.SetBool("EnemyWalk", false);
        MonsterAnimation.SetBool("EnemyAttack", false);
        MonsterAnimation.SetBool("EnemyIdle", false);
        MonsterAnimation.SetBool("EnemyRun", true);
        MonsterAnimation.SetFloat("Speed", 5f);

    }

}
