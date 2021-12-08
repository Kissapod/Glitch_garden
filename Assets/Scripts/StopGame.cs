using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    public GameObject pauseActive;
    public static bool pause;
    private GameObject pausePanel;

    public void Pause(bool isPause)
    {
        if (isPause == false)
        {
            Destroy(pausePanel);
            Time.timeScale = 1f;
            pause = false;
        }
        else if (isPause == true)
        {
            pausePanel = Instantiate(pauseActive);
            Time.timeScale = 0;
            pause = true;
        }
    }
}
