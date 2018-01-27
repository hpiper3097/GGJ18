using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneTimeDoorBehavior : MonoBehaviour
{

    private bool isOpen;
    private bool isOpening;
    private bool isClosing;
    private float alphaLevel = .1f;

    // Use this for initialization
    void Start()
    {
        isOpen = false;
        isOpening = false;
        isClosing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if door is opening 
        if (isOpening)
        {
            //and door is not all the way open
            if (!isOpen)
            {
                Vector4 color = gameObject.GetComponent<MeshRenderer>().material.color;
                //keep opening as long as the door is visible
                if (color.w > 0)
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = new Vector4(color.x, color.y, color.z, color.w - alphaLevel);
                }
                //else set the door to open. no longer opening.
                else
                {
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    isOpen = true;
                    isOpening = false;
                }

            }
        }
        //else the door is closing
        else if (isClosing)
        {
            Vector4 color = gameObject.GetComponent<MeshRenderer>().material.color;
            gameObject.GetComponent<MeshRenderer>().material.color = new Vector4(color.x, color.y, color.z, color.w + alphaLevel);
            //if the door is still closing
            if (color.w <= 1)
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }
            //else the door has completewly closed.
            else
            {
                isOpen = false;
                isClosing = false;
            }
        }

    }




    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOpening = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        isClosing = true;
        isOpen = false;
    }
}
