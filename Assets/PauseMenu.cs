using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseMenuUI;
    
    void Start()
    {
        Time.timeScale = 1f;
        isPaused = false;
        PauseMenuUI.SetActive(false);
    }

    public void OpenPause()
    {
        PauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void OpenShop()
    {
        
        isPaused = false;
        Time.timeScale = 0.05f;
    }
    public void CloseShop()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void ClosePause()
    {
        PauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
