using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTile : MonoBehaviour {

    public int modifier = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<CharacterComponent>().speed /= modifier;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<CharacterComponent>().speed *= modifier;
    }
}
