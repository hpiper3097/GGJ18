using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTake : MonoBehaviour {

    // Use this for initialization

    private Manager m;

	void Start () {
        m = GameObject.FindWithTag("Manager").GetComponent<Manager>();
	}

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            if (other.gameObject.tag == "Controllable" && other.gameObject == m.nearestEntity)
            {
                other.gameObject.GetComponent<Light>().intensity = 10;
            }
            else if(other.gameObject.tag == "Controllable")
                other.gameObject.GetComponent<Light>().intensity = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(gameObject.tag == "Player")
        {
            if(other.gameObject.tag == "Controllable")
            {
                other.gameObject.GetComponent<Light>().intensity = 0;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
