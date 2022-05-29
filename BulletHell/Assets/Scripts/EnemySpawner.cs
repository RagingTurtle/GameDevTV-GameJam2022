using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform floor;
    [SerializeField] private Transform enemy;
    private void Start()
    {
        Vector3 floorAreaCenter = floor.position;
        Vector3 floorAreaRange = floor.localScale / 2.0f;
        float randomLocationX = floorAreaRange.x;
        float surfaceLocationY = (floorAreaRange.y);
        float randomLocationZ = Random.Range(-floorAreaRange.z, floorAreaRange.z);
        Vector3 randomFloorAreaRange = new Vector3(randomLocationX, surfaceLocationY, randomLocationZ);
        Vector3 randomLocation = floorAreaCenter + randomFloorAreaRange;
        enemy.position = randomLocation;
    }
}
