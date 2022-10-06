using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AttackState : State
{
    public Transform target;
    public GameObject enemy;
    public NavMeshAgent agent;

    public ChaseState chasestate;

    public bool inAttackRange;
    public bool inRange;

    public float timeBetweenAttack;
    bool alreadyAttacked;

    public float attackRange;
    public float sightRange;

    public Animator MonsterAnimation;

    public void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }
    public override State RunCurrentState()
    {
        AttackAnimation();
        inRange = FindObjectOfType<CheckIfInRange>().GetPlayerIfIn();
        inAttackRange = FindObjectOfType<ChaseState>().GetInAttackRange();

        if (Vector3.Distance(enemy.transform.position, target.position) > 2.0f)
        {
            inAttackRange = false;
            inRange = true;
        }

        if (inRange && !inAttackRange)
        {
            FindObjectOfType<ChaseState>().SetInAttackRange(false);
            return chasestate;
        }

        else
        {
            return this;
        }
    }

    void AttackAnimation()
    {
        MonsterAnimation.SetBool("EnemyWalk", false);
        MonsterAnimation.SetBool("EnemyAttack", true);
        MonsterAnimation.SetBool("EnemyIdle", false);
        MonsterAnimation.SetBool("EnemyRun", false);
        MonsterAnimation.SetFloat("Speed", 0f);

    }

}
