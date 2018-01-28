using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour {
    //if collision w/ player object, rigidbody = dynamic; else static, if(dynamic) box.vel = player.vel
    // Use this for initialization

    private bool playerCollision = false;
    private bool moveableCollision = false;
    private GameObject pTemp;
    private Rigidbody rb;

	void Start () {
        gameObject.isStatic = true;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Moveable")
        {
            moveableCollision = true;
        }

        if (collision.gameObject.tag == "Player")
            playerCollision = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pTemp = collision.gameObject;
        }
        else if (collision.gameObject.tag == "Moveable")
            rb.velocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.isStatic = true;
            playerCollision = false;
        }
    }

    // Update is called once per frame
    void Update () {

        Vector3 posTemp = rb.position;

        if (!playerCollision)
            rb.velocity = new Vector3(0, 0, 0);
   
        if (moveableCollision && playerCollision)
            rb.position = posTemp;
    }
}
