using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private Manager m;
    private CharacterComponent c;
    public bool active;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        m = GameObject.FindWithTag("Manager").GetComponent<Manager>();
        c = gameObject.GetComponent<CharacterComponent>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (active)
        {
            float moveV = Input.GetAxis("Vertical");
            float moveH = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2(moveH, moveV);
            rb.velocity = movement * c.speed;
            //swap on space
            if(Input.GetKeyDown("space"))
            {
                m.EntityChangeA(gameObject);
                rb.velocity = Vector2.zero;
            }
        }
    }

    public void SetState(bool boo)
    {
        active = boo;
    }
}


