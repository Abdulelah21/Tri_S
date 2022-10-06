using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Linq;

namespace Assets.MonsterFSM
{
    public class MonsterControlPoint : MonoBehaviour
    {
        [SerializeField] protected float debugDrawRadius = 1.0f;

        [SerializeField] protected float _connectivityRadius = 3.0f;

        List<MonsterControlPoint> _connections;


        // Use this for initialization
        void Start()
        {
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("PatrolPoint");

            _connections = new List<MonsterControlPoint>();

            for(int i = 0; i < allWaypoints.Length; i++)
            {
                MonsterControlPoint nextWaypoint = allWaypoints[i].GetComponent<MonsterControlPoint>();

                if(nextWaypoint != null)
                {
                    if(Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= _connectivityRadius && nextWaypoint != this)
                    {
                        _connections.Add(nextWaypoint);
                    }
                }
                
            }
                      
        }

        public  void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, debugDrawRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, _connectivityRadius);

        }


        public MonsterControlPoint NextWaypoint(MonsterControlPoint prevoisWaypoint)
        {
            if(_connections.Count == 0)
            {
                Debug.LogError("Insufficient waypoint count .");
                return null;
            }
            else if (_connections.Count == 1 && _connections.Contains(prevoisWaypoint))
            {
                return prevoisWaypoint;
            }

            else
            {
                MonsterControlPoint nextWaypoint;
                int nextIndex = 0;

                do
                {
                    nextIndex = UnityEngine.Random.Range(0, _connections.Count);
                    nextWaypoint = _connections[nextIndex];
                } while (nextWaypoint == prevoisWaypoint);
               
                return nextWaypoint;
            }


        }






        // Update is called once per frame
        void Update()
        {

        }
    }
}