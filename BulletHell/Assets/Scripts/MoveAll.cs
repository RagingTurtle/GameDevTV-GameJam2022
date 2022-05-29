using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAll : MonoBehaviour
{
    public float adjust;
    void Update()
    {
        for (int children = transform.childCount; children > 0;)
        {
            children--;
            Transform theChild = transform.GetChild(children);
            if (theChild.GetComponent<NavMeshAgent>() != null)
            {
                
            }
            else
            {
                transform.GetChild(children).position = new Vector3(
                transform.GetChild(children).position.x - adjust * Time.deltaTime,
                transform.GetChild(children).position.y,
                transform.GetChild(children).position.z);
            }
        }
    }
}
