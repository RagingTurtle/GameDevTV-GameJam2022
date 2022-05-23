using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public bool walkPointSet;
    public Vector3 walkPoint;
    public float WalkPointRange;
    public LayerMask Floor;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!walkPointSet)
        {
            walkPoint = new Vector3(transform.position.x + WalkPointRange, transform.position.y, transform.position.z);
            WalkPointRange *= -1;

            if (Physics.Raycast(walkPoint, -transform.up, 2f, Floor))
            {
                walkPointSet = true;
            }
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
}
