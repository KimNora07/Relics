using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PausePanel;

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
