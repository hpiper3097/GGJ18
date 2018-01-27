using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour {

    private bool isClosed;
    private float alphaLevel = .1f;

	// Use this for initialization
	void Start () {
        isClosed = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isClosed)
        {
            Vector4 color = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            //Debug.Log(color.w);
            if(color.w <=1)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Vector4(color.x, color.y, color.z, color.w + alphaLevel);
            }
            else
                isClosed = true;
        }
        
	}

    
        
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector4 color = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = new Vector4(color.x, color.y, color.z, color.w - alphaLevel);
            if(color.w <=  0)
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isClosed = false;
    }
}
