using BehaviourTree;
using UnityEngine.AI;
public class EnemyOneBT : Tree
{
public UnityEngine.Transform[] waypoints;
public static float speed = 2f;
    NavMeshAgent agent;

    protected  override Node SetupTree()
    {
        Node root = new TaskPatrol(transform, waypoints);
        return root;
    }


}
