using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickHandler : MonoBehaviour
{

    private bool loadLock;

    private void Start()
    {
        this.loadLock = true;
        Invoke("unlockLoadLock", 2);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        if (!loadLock) SceneManager.LoadScene("Menu");
    }

    private void unlockLoadLock()
    {
        this.loadLock = false;
    }
}
