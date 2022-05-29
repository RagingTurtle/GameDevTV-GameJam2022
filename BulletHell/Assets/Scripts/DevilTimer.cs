using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilTimer : MonoBehaviour
{
    [SerializeField] private Timer timer;
    
    private void Start() {
        timer.countDown = false;
        timer.currentTime = 0f;
        timer.hasLimit = false;
    }

}
