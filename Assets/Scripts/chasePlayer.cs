using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour {

    
    private bool chasing;
    private bool returning;
    private Transform target; //the enemy's target
    private int moveSpeed = 3; //move speed
    public float range = 10f;
    private float stop = 0;
    private Transform self; //current transform data of this enemy
    public float speed = 1;
    private Rigidbody rb;
    private Transform originalPosition;


    void Awake()
    {
        self = transform; //cache transform data for easy access/performance
        rb =  gameObject.GetComponent<Rigidbody>();
        chasing = false;
        returning = false;
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //target the player
        originalPosition = self;
    }

    void FixedUpdate()
    {

        //target the player
        target = GameObject.FindWithTag("Player").transform;
        //update distance  to target
        float distance = Vector3.Distance(self.position, target.position);
        //check to make sure within aggro range
        if (distance < range)
        {
            //set chasing to true
            chasing = true;
            //if chasing is true
            if(chasing)
            {
                //target the player
                target = GameObject.FindWithTag("Player").transform;
                //update direction vector and follow target
                Vector3 directionVector = new Vector3(target.position.x - self.position.x, self.position.y, target.position.z - self.position.z);
                rb.velocity = directionVector * speed;
            }
            else
            {
                //go back to original position
                target = originalPosition;
                Vector3 directionVector = new Vector3(target.position.x - self.position.x, self.position.y, target.position.z - self.position.z);
                rb.velocity = directionVector * speed;
            }
        }
        else
        {
            chasing = false;
            target = originalPosition;
        }
    }

}
