using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private Manager m;
    private CharacterComponent c;
    public bool active;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        m = GameObject.FindWithTag("Manager").GetComponent<Manager>();
        c = gameObject.GetComponent<CharacterComponent>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (active)
        {
            float moveV = Input.GetAxis("Vertical");
            float moveH = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveH, rb.velocity.y/c.speed, moveV);
            rb.velocity = movement * c.speed;
            //swap on space
            if(Input.GetKeyDown("space"))
            {
                m.EntityChangeA(gameObject);
                rb.velocity = Vector3.zero;
            }
        }
    }

    public void SetState(bool boo)
    {
        active = boo;
    }
}


