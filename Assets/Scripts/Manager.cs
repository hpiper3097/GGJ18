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
        float dif = 1000.0f;
        foreach(var i in entities)
        {
            if (new Vector2(Mathf.Abs(player.GetComponent<Rigidbody2D>().position.x - i.GetComponent<Rigidbody2D>().position.x),
                Mathf.Abs(player.GetComponent<Rigidbody2D>().position.y - i.GetComponent<Rigidbody2D>().position.y)).magnitude < dif)
            {
                newPlayer = i;
                dif = new Vector2(Mathf.Abs(player.GetComponent<Rigidbody2D>().position.x - i.GetComponent<Rigidbody2D>().position.x),
                Mathf.Abs(player.GetComponent<Rigidbody2D>().position.y - i.GetComponent<Rigidbody2D>().position.y)).magnitude;
            }
        }
        player.GetComponent<PlayerController>().SetState(false);
        player.tag = "Controllable";
        if (newPlayer)
        {
            newPlayer.GetComponent<PlayerController>().SetState(true);
            newPlayer.tag = "Player";
        }
    }

    public string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }

}
