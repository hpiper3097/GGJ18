using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour {

    public bool active;
    public float watchSpeed;
    private int watching;
    private SpriteRenderer sprite;
    private Vector4 colors;
    // Use this for initialization
    void Start () {
        //initialize values related to watching
        
        watching = 0;
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>(); //bad practice, should try to assign this in the editor but it's a game jam so im not rdoing this
        colors = sprite.color;
        sprite.color = new Vector4(colors.x, colors.y, colors.z, 0);
        sprite.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            if (watching != 0)
            {
                colors = sprite.color;
                sprite.color = new Vector4(colors.x, colors.y, colors.z, colors.w + watchSpeed / 65);
                if (colors.w >= 1)
                {
                    Destroy(gameObject);
                }
            }
            else if (colors.w > 0)
            {
                colors = sprite.color;
                sprite.color = new Vector4(colors.x, colors.y, colors.z, colors.w - watchSpeed / 65);
                sprite.enabled = false;
            }
        }
    }
    //keep a count of the number of things watching the player
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            watching++;
            sprite.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            watching--;
    }

    public void SetState(bool boo)
    {
        active = boo;
    }

}

