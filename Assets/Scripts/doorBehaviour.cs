using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorBehaviour : MonoBehaviour
{

    private bool isOpen;
    private bool isOpening;
    private bool isClosing;
    private float alphaLevel = .1f;
    public string sceneName;
    private bool[] key;

	// Use this for initialization
	void Start () {
        isOpen = false;
        isOpening = false;
        isClosing = false;
        key = new bool[2];
	}
	
	// Update is called once per frame
	void Update () {
        //if door is opening 
		if(isOpening)
        {
            //and door is not all the way open
            if (!isOpen)
            {
                Vector4 color = gameObject.GetComponent<MeshRenderer>().material.color;
                //keep opening as long as the door is visible
                if (color.w >= 0)
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = new Vector4(color.x, color.y, color.z, color.w - alphaLevel);
                }
                else //set the door to open. no longer opening.
                {
                    gameObject.GetComponent<MeshCollider>().isTrigger = true;
                    isOpen = true;
                    isOpening = false;
                    
                }

            }
            else //door is opening and open
            {
                //do nothing because player is inside the doorway
            }
        }
        //else the door is closing
        else if (isClosing)
        {
            gameObject.GetComponent<MeshCollider>().isTrigger = false;
            Vector4 color = gameObject.GetComponent<MeshRenderer>().material.color;
            //if the door is still closing
            if (color.w <= 1)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = new Vector4(color.x, color.y, color.z, color.w + alphaLevel);
            }
            else //the door has completely closed.
            {
                isOpen = false;
                isClosing = false;
            }
        }
        
	}

    private void OnCollisionEnter(Collision other)
    {
        if (key[0] == false && key[1] == false)
            if (other.gameObject.tag == "Controllable")
            {
                isOpening = true;
                if (sceneName != null)
                    SceneManager.LoadScene(sceneName);
            }

            else if (key[0] == false && key[1] == true)
            {
                if (other.gameObject.tag == "Controllable" && key == other.gameObject.GetComponent<CharacterComponent>().unlock)
                {
                    isOpening = true;
                }
            }

            else if (key[0] == true && key[1] == false)
            {
                if (other.gameObject.tag == "Controllable" && key == other.gameObject.GetComponent<CharacterComponent>().unlock)
                {
                    isOpening = true;
                }
            }
    }

    private void OnCollisionExit(Collision collision)
    {
        isOpen = false;
        if(isOpening)
        {
            isOpening = false;
            isClosing = true;
        }
        
        
    }

    private void OnTriggerExit(Collider collision)
    {
        isClosing = true;
        isOpen = false;
        
    }
}
