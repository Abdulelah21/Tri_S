using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class TaskPatrol : Node
{

    private Transform _transform;
    private Transform[] _waypoints;
    NavMeshAgent agent;


    private int _currentWayPointIndex = 0;

    private float _waitTime = 7f;
    private float _waitCounter = 0f;
    private bool _waiting = false;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
    }

    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            Debug.Log("Wait "+_waitTime+" Seconds");
            _waitCounter += Time.deltaTime;
            if (_waitCounter < _waitTime)
            _waiting = false;
        }
        else
        {
            Transform wp = _waypoints[_currentWayPointIndex];
            if (Vector3.Distance(_transform.position, wp.position) < 0.8f)
            {
                Debug.Log("Wait " + _waitCounter+ " Seconds");
                _transform.position = wp.position;
                _waitCounter = 0f;
                _waiting = true;

                _currentWayPointIndex = (_currentWayPointIndex + 1) % _waypoints.Length;

            }
            else
            {
                _transform.position = Vector3.MoveTowards(_transform.position, wp.position, EnemyOneBT.speed * Time.deltaTime);
                Vector3 targetPosition = new Vector3(wp.transform.position.x, wp.position.y, wp.transform.position.z);
                _transform.LookAt(targetPosition);
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}
