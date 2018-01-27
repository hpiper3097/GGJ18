using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private Manager m;
    public int speed = 10;
    public bool active;
    private Text textClock;
    private float timerDuration;
    private float timerStartTime;


    // Use this for initialization
    void Start () {
        //clock
        textClock = GetComponent<Text>();
        TimerReset(30);

        rb = gameObject.GetComponent<Rigidbody2D>();
        m = GameObject.FindWithTag("Manager").GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //clock
        string timerMessage = "YOU LOSE!!!";
        int timeLeft = (int) TimerRemaining();
        if (timeLeft > 0)
            timerMessage = "Seconds Remaining = " + m.LeadingZero(timeLeft);


        if (active)
        {
            float moveV = Input.GetAxis("Vertical");
            float moveH = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2(moveH, moveV);
            rb.velocity = movement * speed;

            if(Input.GetKeyDown("space"))
            {
                m.EntityChangeA(gameObject);
            }
        }
    }

    public void TimerReset(float delay)
    {
        timerDuration = delay;
        timerStartTime = Time.time;
    }

    public float TimerRemaining()
    {
        float timeSpent = Time.time - timerStartTime;
        float timeLeft = timerDuration - timeSpent;
        return timeLeft;
    }

    public void SetState(bool boo)
    {
        active = boo;
    }
}


