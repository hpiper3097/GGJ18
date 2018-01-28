using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public bool paused = false;
    public GameObject quit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            paused = togglePause();
    }

    void OnGUI()
    {
        if (paused)
        {
            GUILayout.Label("Game is paused!");
                paused = togglePause();
            SceneManager.LoadScene("pauseMenu");
        }
    }





    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}