using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
    public void playclick()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void quitclick()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
