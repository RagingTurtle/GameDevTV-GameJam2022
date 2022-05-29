using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private Timer timer;

    private void Start()
    {
        timer.countDown = true;
        timer.currentTime = PlayerPrefs.GetFloat("secondsToLive", 0f);
        timer.timerLimit = 0f;
        timer.hasLimit = true;
    }
}
