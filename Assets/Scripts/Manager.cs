using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject[] entities;
    public GameObject nearestEntity;

	// Use this for initialization
	void Start () {
        entities = GameObject.FindGameObjectsWithTag("Controllable");
	}
	
	// Update is called once per frame
	void Update () {
        entities = GameObject.FindGameObjectsWithTag("Controllable");
        findNearest(GameObject.FindWithTag("Player"));
    }

    public void findNearest(GameObject player)
    {
        float dif = 999.0f;
        foreach (var i in entities)
        {
            float vecDiff = Vector3.Distance(player.GetComponent<Rigidbody>().position, i.GetComponent<Rigidbody>().position);
            if (vecDiff < dif)
            {
                dif = vecDiff;
                nearestEntity = i;
            }
        }
    }

    public void EntityChangeA(GameObject player)
    {
        int pdTT = player.GetComponent<CharacterComponent>().distanceToTake;
        Vector2 ePos = nearestEntity.GetComponent<Rigidbody>().position;
        findNearest(player);
            //comments are for pussies
            if (Vector2.Distance(ePos, player.GetComponent<Rigidbody>().position) < pdTT )
        {
            player.GetComponent<PlayerController>().SetState(false);
            player.tag = "Controllable";
            nearestEntity.GetComponent<PlayerController>().SetState(true);
            nearestEntity.tag = "Player";
            nearestEntity.GetComponent<Light>().intensity = 0;
        }
     
    }
}
