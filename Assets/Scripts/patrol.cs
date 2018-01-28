// patrol.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class patrol : MonoBehaviour
{
    private Transform self;
    private Transform target;
    private bool patrolling;
    private bool chasing;
    public float range = 10f;
    private float stop = 0;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public int speed;
    private Rigidbody rb;

    void Start()
    {
        patrolling = true;

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        self = transform; //cache transform data for easy access/performance
        rb = gameObject.GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform; //target the player
        agent = GetComponent<NavMeshAgent>();
        agent.acceleration = speed;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        //if patrolling
        if (patrolling)
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
            else
            {
                //get distance from player
                target = GameObject.FindWithTag("Player").transform; //target the player
                float distance = Vector3.Distance(self.position, target.position);
                //check to see if target is within range
                if (distance < range)
                {
                    //stop patrolling, start chasing
                    patrolling = false;
                }
            }
        }
        else //chasing
        {
            target = GameObject.FindWithTag("Player").transform; //target the player
            float distance = Vector3.Distance(self.position, target.position);
            //update direction vector and follow target
            Vector3 directionVector = new Vector3(target.position.x - self.position.x, self.position.y, target.position.z - self.position.z);
            rb.velocity = directionVector * speed;
            //distance to target is greater than the allowed range or the distance to the target is less than 0
            if (distance > range || distance < stop)
            {
                //stop following the player
                rb.velocity = new Vector3(0, 0, 0);
                patrolling = true;
            }
        }


        }

    }


