using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int timeLeft = 30;
    public Text timerText ;


	// Use this for initialization
	void Start () {
        StartCoroutine("LoseTime");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timerText.text = ("Time Left = " + timeLeft);
        if(timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            timerText.text = "You LOSE!";
        }
	}

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
