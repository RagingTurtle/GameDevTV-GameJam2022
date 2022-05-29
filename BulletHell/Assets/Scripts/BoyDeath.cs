using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoyDeath : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject DeathCanvas;
    [SerializeField] private TMPro.TextMeshProUGUI DeathMessage;
    [SerializeField] private string sceneName;
    public int treesCollected;
    private void OnDisable()
    {
        timer.currentTime = 0f;
    }
    private void Update()
    {
        if (timer.currentTime == 0)
        {
            PlayerPrefs.SetInt("treesCollected", treesCollected);
            DeathCanvas.SetActive(true);
            string msg = "You have died.\nYou have ";
            msg += treesCollected.ToString();
            msg += " trees to block you from the devil.";
            DeathMessage.text = msg;
            gameObject.SetActive(false);
        }

    }

    public void LoadSceneButton()
    {
        SceneManager.LoadScene(sceneName);
    }

}
