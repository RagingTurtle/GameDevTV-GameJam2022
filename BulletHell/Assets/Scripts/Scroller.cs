using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float adjust;
    void Update()
    {
        for (int children = transform.childCount; children > 0; ){
            children--;
            transform.GetChild(children).position = new Vector3 (
                transform.GetChild(children).position.x - adjust*Time.deltaTime,
                transform.GetChild(children).position.y,
                transform.GetChild(children).position.z);
        }
    }
}
