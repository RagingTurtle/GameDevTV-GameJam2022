using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField] private int bulletsAmount = 10;
    [SerializeField] private float startAngle = 0f, endAngle = 360f;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private Transform mouth;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private ObjectPool bulletPoolInstance;
    [SerializeField] private bool hasTarget;
    [SerializeField] private Transform target;
    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);
    }

    private void Fire()
    {
        if (hasTarget)
        {
            FireBullet(target.position);
        }
        else
        {
            float angleStep = (endAngle - startAngle) / bulletsAmount;
            float angle = startAngle;
            for (int i = 0; i < bulletsAmount + 1; i++)
            {
                float bulletDirectionX = mouth.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulletDirectionY = mouth.position.y;
                float bulletDirectionZ = mouth.position.z + Mathf.Cos((angle * Mathf.PI) / 180f);
                Vector3 bulletMoveVector = new Vector3(bulletDirectionX, bulletDirectionY, bulletDirectionZ);
                FireBullet(bulletMoveVector);
                angle += angleStep;
            }
        }

        void FireBullet(Vector3 bulletMoveVector)
        {
            Vector3 bulletDirection = (bulletMoveVector - mouth.position).normalized;

            GameObject bullet = bulletPoolInstance.GetObject();
            bullet.transform.position = mouth.position;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetBulletSpeed(bulletSpeed);
            bullet.GetComponent<Bullet>().SetMoveDirection(bulletDirection);
        }
    }
}
