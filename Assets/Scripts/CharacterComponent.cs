using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour {

    public int distanceToTake;
    public int distanceToGetTook;

    public float speed;

    public bool[] unlock = new bool[2];

    public float health;
}
