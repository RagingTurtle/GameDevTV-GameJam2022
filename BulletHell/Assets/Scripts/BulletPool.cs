using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private bool notEnoughBullets = true;
    private List<GameObject> bullets;
    private void Awake()
    {
        bulletPoolInstance = this;
    }
    private void Start()
    {
        bullets = new List<GameObject>();
        GameObject bul = Instantiate(bulletPrefab);
        bul.SetActive(false);
        bullets.Add(bul);

    }
    public GameObject GetBullet()
    {
        Debug.Log("Hi");

        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }
        if (notEnoughBullets)
        {
            GameObject bul = Instantiate(bulletPrefab);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
}
