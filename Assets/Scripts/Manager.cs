using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject[] entities;

	// Use this for initialization
	void Start () {
        entities = GameObject.FindGameObjectsWithTag("Controllable");
	}
	
	// Update is called once per frame
	void Update () {
        entities = GameObject.FindGameObjectsWithTag("Controllable");
    }

    public void EntityChangeA(GameObject player)
    {
        GameObject newPlayer = null;
        int pdTT = player.GetComponent<CharacterComponent>().distanceToTake;
        float dif = 999.0f;
        foreach(var i in entities)
        {
            int idTGT = i.GetComponent<CharacterComponent>().distanceToGetTook;
            //comments are for pussies
            if (new Vector2(Mathf.Abs(player.GetComponent<Rigidbody2D>().position.x - i.GetComponent<Rigidbody2D>().position.x),
                Mathf.Abs(player.GetComponent<Rigidbody2D>().position.y - i.GetComponent<Rigidbody2D>().position.y) ).magnitude < pdTT
                && new Vector2(Mathf.Abs(player.GetComponent<Rigidbody2D>().position.x - i.GetComponent<Rigidbody2D>().position.x),
                Mathf.Abs(player.GetComponent<Rigidbody2D>().position.y - i.GetComponent<Rigidbody2D>().position.y)).magnitude < idTGT
                && new Vector2(Mathf.Abs(player.GetComponent<Rigidbody2D>().position.x - i.GetComponent<Rigidbody2D>().position.x),
                Mathf.Abs(player.GetComponent<Rigidbody2D>().position.y - i.GetComponent<Rigidbody2D>().position.y)).magnitude < dif)
            {
                newPlayer = i;
                dif = new Vector2(Mathf.Abs(player.GetComponent<Rigidbody2D>().position.x - i.GetComponent<Rigidbody2D>().position.x),
                Mathf.Abs(player.GetComponent<Rigidbody2D>().position.y - i.GetComponent<Rigidbody2D>().position.y)).magnitude;
            }
        }
        if (newPlayer)
        {
            player.GetComponent<PlayerController>().SetState(false);
            player.tag = "Controllable";
            newPlayer.GetComponent<PlayerController>().SetState(true);
            newPlayer.tag = "Player";
        }
    }
}
