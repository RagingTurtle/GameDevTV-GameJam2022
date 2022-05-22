using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 moveDirection;
    private float moveSpeed;
    private void OnEnable()
    {
        Invoke("Destroy", 4f);
    }
    private void Start()
    {
        moveSpeed = 4f;
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    public void SetMoveDirection(Vector3 dir)
    {
        moveDirection = dir;
    }

    public void SetBulletSpeed(float bulletSpeed)
    {
        moveSpeed = bulletSpeed;
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Ghost")
        {
            other.GetComponent<HitCount>().hits += 1;
        }
        if (other.transform.tag == "Gravestone"){
            other.GetComponent<HitCount>().hits +=1;
            Destroy();
        }
    }
}