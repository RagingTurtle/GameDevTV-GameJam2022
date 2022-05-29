using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;

    public bool walkPointSet;
    public Vector3 walkPoint;
    public LayerMask Floor;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startingPosition = transform.position;
    }
    private void Update()
    {
        if (!walkPointSet)
        {
            if (period <= Mathf.Epsilon) { return; }
            float cycles = Time.time / period;
            const float tau = Mathf.PI * 2;
            float rawSinWave = Mathf.Sin(cycles * tau);

            movementFactor = (rawSinWave + 1f) / 2f;

            Vector3 offset = movementVector * movementFactor;
            walkPoint = startingPosition + offset;

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
