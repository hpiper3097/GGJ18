using UnityEngine;
using System.Collections;

public class followCamera : MonoBehaviour
{

    public string target;
    public float damping = 1;
    Vector3 offset;
    
    void Start()
    {
        offset = transform.position - GameObject.FindWithTag(target).transform.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = GameObject.FindWithTag(target).transform.position + offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;

        transform.LookAt(GameObject.FindWithTag(target).transform.position);
    }
}