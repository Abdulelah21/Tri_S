using System.Collections;
using Assets.MonsterFSM;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.MonsterFSM
{

    [RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]

    public class Monster : MonoBehaviour
    {
        [SerializeField] MonsterControlPoint[] _patrolPoints;

        NavMeshAgent _agent;
        FiniteStateMachine _finiteStateMachine;


        public void Awake()
        {
            _agent = this.GetComponent<NavMeshAgent>();
            _finiteStateMachine = this.GetComponent<FiniteStateMachine>();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public MonsterControlPoint[] PatrolPoints
        {
            get
            {
                return _patrolPoints;
            }
        }
    }
}