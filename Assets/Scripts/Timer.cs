using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float time = 30f;
    [SerializeField] Canvas victoryCanvas;


    private void Update()
    {
        time -= Time.deltaTime;
        float roundedTime = Mathf.RoundToInt(time);
        timerText.text = roundedTime.ToString() + "s";

        if (time < 0)
        {
            time = 0;

            victoryCanvas.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        victoryCanvas.enabled = false;
        Time.timeScale = 1;
    }
}
