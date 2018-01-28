using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistance : MonoBehaviour {

    public bool[] ids = new bool[50];

	// Use this for initialization
	void Start () {
        for (int i = 0; i < ids.Length; i++)
            ids[i] = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
