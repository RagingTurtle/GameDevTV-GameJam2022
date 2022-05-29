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
    [SerializeField] private string sceneName;

    private void OnDisable()
    {
        timer.StopTimer();
        PlayerPrefs.SetFloat("secondsToLive", timer.currentTime);
        DeathCanvas.SetActive(true);
        string msg = "You have died.\nYou have ";
        msg += timer.currentTime.ToString();
        msg += " seconds of life.";
        DeathMessage.text = msg;
    }
    
        public void LoadSceneButton()
    {
        SceneManager.LoadScene(sceneName);
    }

}
