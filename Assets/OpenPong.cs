using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPong : MonoBehaviour
{
    public static bool is1Player;
    public void Open2PlayerMode()
    {
        SceneManager.LoadScene("Pong");
        is1Player = false;
    }
    public void Open1PlayerMode()
    {
        SceneManager.LoadScene("Pong");
        is1Player = true;
    }
    public void ClosePlayerMode()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
