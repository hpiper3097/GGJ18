using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAlpha : MonoBehaviour
{

    public float alpha;
    public float alphaSpeed;
    private Vector4 colors;
    private MeshRenderer model;
    private bool decreasing;

    // Use this for initialization
    void Start()
    {
        model = gameObject.GetComponent<MeshRenderer>();

    }

    // Im a salty sailor
    void Update()
    {/*
        colors = model.material.color;
        if (decreasing)
            if(colors.w > alpha)
                model.material.color = new Vector4(colors.x, colors.y, colors.z, colors.w - alphaSpeed);
        else
            if(colors.w <= 1)
                model.material.color = new Vector4(colors.x, colors.y, colors.z, colors.w + alphaSpeed);*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //decreasing = true;
            Debug.Log("Enter");
            colors = model.material.color;
            model.material.color = new Vector4(colors.x, colors.y, colors.z, alpha);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //decreasing = false;
            Debug.Log("Exit");
            colors = model.material.color;
            model.material.color = new Vector4(colors.x, colors.y, colors.z, 1);
        }
    }
}
