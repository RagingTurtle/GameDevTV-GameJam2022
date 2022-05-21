using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField] private int bulletsAmount = 10;
    [SerializeField] private float startAngle = 0f, endAngle = 360f;
    [SerializeField] private float fireRate =2f;
    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;
        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulletDirectionX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirectionY = transform.position.y;
            float bulletDirectionZ = transform.position.z + Mathf.Cos((angle * Mathf.PI) / 180f);
            Vector3 bulletMoveVector = new Vector3(bulletDirectionX, bulletDirectionY, bulletDirectionZ);
            Vector3 bulletDirection = (bulletMoveVector - transform.position).normalized;

            GameObject bullet = BulletPool.bulletPoolInstance.GetBullet();
                    Debug.Log(BulletPool.bulletPoolInstance.GetBullet().name);

            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetMoveDirection(bulletDirection);
            angle += angleStep;
        }
    }
}
