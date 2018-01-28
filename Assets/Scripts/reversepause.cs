using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reversepause : MonoBehaviour
{
    public bool paused = false;
    public GameObject quit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            paused = toggleResume();
    }

    void OnGUI()
    {
        if (!paused)
        {
            paused = toggleResume();
            SceneManager.LoadScene("LevelOne");
        }
    }



    bool toggleResume()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return true;
        }
        else
        {
            Time.timeScale = 0f;
            return false;
        }
    }


}