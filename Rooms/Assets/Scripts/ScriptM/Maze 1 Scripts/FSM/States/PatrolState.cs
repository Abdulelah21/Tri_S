using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PatrolState : State
{
    public IdleState idlestate;
    public RunState runstate;
    public ChaseState chasestate;

    public bool glassSharpAnimation;
    public bool doneWalking;
    public bool inRange;

    public NavMeshAgent agent;



    public void Awake()
    {

        doneWalking = false;
    }

   
    public override State RunCurrentState()
    {
        agent.speed = 3f;
       


        if (inRange)
        {
            return chasestate;
        }

       else if (doneWalking)
        {
            Debug.Log("Done");
            return idlestate;
        }
        else if(glassSharpAnimation)
        {
            return runstate;
        }
        else
        {
            return this;
        }

   

    }



}
