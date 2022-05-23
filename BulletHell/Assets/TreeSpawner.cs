using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] private int treeAmount = 10;
    [SerializeField] private float growRate = 2f;
    [SerializeField] private Transform plantingArea;
    [SerializeField] private ObjectPool treePoolInstance;
    private void Start()
    {
        InvokeRepeating("SpawnTrees", 0f, growRate);
    }
    private void SpawnTrees()
    {
        if (treeAmount > 0)
        {
            --treeAmount;
            Vector3 plantingAreaCenter = plantingArea.transform.position;
            Vector3 plantingAreaRange = plantingArea.transform.localScale / 2.0f;
            float randomLocationX = Random.Range(-plantingAreaRange.x, plantingAreaRange.x);
            float surfaceLocationY = (plantingAreaRange.y);
            float randomLocationZ = Random.Range(-plantingAreaRange.z, plantingAreaRange.z);
            Vector3 randomPlantingAreaRange = new Vector3(randomLocationX, surfaceLocationY, randomLocationZ);
            Vector3 randomLocation = plantingAreaCenter + randomPlantingAreaRange;
            GameObject tree = treePoolInstance.GetObject();
            tree.transform.position = randomLocation;
            tree.SetActive(true);
        }
        else
        {
            CancelInvoke();
        }
    }
}
