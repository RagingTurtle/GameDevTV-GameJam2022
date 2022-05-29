using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GhostDeath : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject DeathCanvas;
    [SerializeField] private TextMeshProUGUI DeathMessage;
    private void OnDisable()
    {
        timer.StopTimer();
        PlayerPrefs.SetFloat("timer", timer.currentTime);
        DeathCanvas.SetActive(true);
        string msg = "You have died.\nYou have ";
        msg += timer.currentTime.ToString();
        msg += " seconds of life.";
        DeathMessage.text = msg;
    }
    
        public void LoadScroller()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
