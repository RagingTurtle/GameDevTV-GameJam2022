using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    [SerializeField] private float growRate = 2.0f;
    [SerializeField] private Transform plantingArea;
    [SerializeField] private ObjectPool SeedPoolInstance;
    private void Start()
    {
        InvokeRepeating("SpawnSeeds", 0f, growRate);
    }
    private void SpawnSeeds()
    {
        Vector3 plantingAreaCenter = plantingArea.transform.position;
        Vector3 plantingAreaRange = plantingArea.transform.localScale / 2.0f;
        float randomLocationX = Random.Range(-plantingAreaRange.x, plantingAreaRange.x);
        float surfaceLocationY = (plantingAreaRange.y);
        float randomLocationZ = Random.Range(-plantingAreaRange.z, plantingAreaRange.z);
        Vector3 randomPlantingAreaRange = new Vector3(randomLocationX, surfaceLocationY, randomLocationZ);
        Vector3 randomLocation = plantingAreaCenter + randomPlantingAreaRange;
        GameObject seed = SeedPoolInstance.GetObject();
        seed.transform.position = randomLocation;
        seed.SetActive(true);
    }
}
