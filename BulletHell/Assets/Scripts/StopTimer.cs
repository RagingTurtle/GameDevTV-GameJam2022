using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimer : MonoBehaviour
{
    [SerializeField] private Timer timer;
    private void OnDisable()
    {
        timer.StopTimer();
    }
}
