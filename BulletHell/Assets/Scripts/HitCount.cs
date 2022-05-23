using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HitCount : MonoBehaviour
{
    [SerializeField] public TMP_Text TextField;
    public int hitPoints = 3;
    void Update()
    {
        TextField.text = hitPoints.ToString();
        if (hitPoints < 1)
        {
            gameObject.SetActive(false);
        }
    }
}
