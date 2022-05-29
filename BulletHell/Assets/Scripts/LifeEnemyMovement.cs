using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LifeEnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform enemyRoamArea;
    [SerializeField] private Transform player;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Vector3 enemyRoamAreaCenter = enemyRoamArea.transform.position;
            Vector3 enemyRoamAreaRange = enemyRoamArea.transform.localScale / 2.0f;
            float randomLocationX = Random.Range(-enemyRoamAreaRange.x, enemyRoamAreaRange.x);
            float surfaceLocationY = (enemyRoamAreaRange.y);
            float randomLocationZ = Random.Range(-enemyRoamAreaRange.z, enemyRoamAreaRange.z);
            Vector3 randomEnemyRoamAreaRange = new Vector3(randomLocationX, surfaceLocationY, randomLocationZ);
            agent.SetDestination(enemyRoamAreaCenter + randomEnemyRoamAreaRange);
        }
        transform.LookAt(player.position);
    }
}
