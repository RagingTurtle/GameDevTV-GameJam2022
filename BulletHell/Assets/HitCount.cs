using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HitCount : MonoBehaviour
{
    [SerializeField] public TMP_Text TextField;
    public int hits=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextField.text = hits.ToString();
    }
}
