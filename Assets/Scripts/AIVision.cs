using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVision : MonoBehaviour {

    private SphereCollider col;

	// Use this for initialization
	void Start ()
    {
        col = gameObject.GetComponent<SphereCollider>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if(check FOV)
            //if(raycast)
            //SEEn!

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
