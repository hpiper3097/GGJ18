﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour {



    private Transform target; //the enemy's target
    private int moveSpeed = 3; //move speed
    public float range = 10f;
    private float stop = 0;
    private Transform self; //current transform data of this enemy
    public float speed = 1;
    private Rigidbody rb;

    void Awake()
    {
        self = transform; //cache transform data for easy access/performance
        rb =  gameObject.GetComponent<Rigidbody>();
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //target the player
    }

    void FixedUpdate()
    {
        //update distance  to target
        float distance = Vector3.Distance(self.position, target.position);
        //check to make sure within aggro range
        if (distance < range && distance > stop)
        {
            //update direction vector and follow target
            Vector3 directionVector = new Vector3(target.position.x - self.position.x, self.position.y, target.position.z - self.position.z);
            rb.velocity = directionVector * speed;
        }
        else
        {
            //stop following the player
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

}
