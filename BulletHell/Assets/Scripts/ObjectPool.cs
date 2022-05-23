using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public ObjectPool objectPoolInstance;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private bool notEnoughObjects = true;
    private List<GameObject> objects;
    private void Awake()
    {
        objectPoolInstance = this;
    }
    private void Start()
    {
        objects = new List<GameObject>();
        GameObject bul = Instantiate(objectPrefab, objectPoolInstance.transform, true);
        bul.SetActive(false);
        objects.Add(bul);

    }
    public GameObject GetObject()
    {
        if (objects.Count > 0)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (!objects[i].activeInHierarchy)
                {
                    return objects[i];
                }
            }
        }
        if (notEnoughObjects)
        {
            GameObject bul = Instantiate(objectPrefab, objectPoolInstance.transform, true);
            bul.SetActive(false);
            objects.Add(bul);
            return bul;
        }
        return null;
    }
}
