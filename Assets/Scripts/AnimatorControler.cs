using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControler : MonoBehaviour
{

    private Animator anim;
    private Rigidbody rb;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x < 0 || rb.velocity.z > 0)
            sprite.flipX = false;
        else
            sprite.flipX = true;
        anim.SetBool("upCheck", rb.velocity.z > 0 || rb.velocity.x > 0);
        anim.SetBool("idleCheck", rb.velocity.magnitude < .1);
    }
}