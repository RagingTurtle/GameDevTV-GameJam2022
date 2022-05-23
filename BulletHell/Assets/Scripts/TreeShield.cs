using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShield : MonoBehaviour
{
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
