using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistanceID : MonoBehaviour {

    //index on the persistence bitflag array
    public int id;
    public static Persistance persist;

	// Use this for initialization
	void Awake () {
        if(persist == null)
        {
            persist = new Persistance();
            DontDestroyOnLoad(persist);
        }
        if (!persist.ids[id])
            GameObject.Destroy(this);
	}
	
}
