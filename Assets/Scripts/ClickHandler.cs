using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickHandler : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
