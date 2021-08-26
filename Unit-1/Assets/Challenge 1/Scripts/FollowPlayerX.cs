using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public float coefficient = 7.0f;
    public Vector3 offset = new Vector3(0, 3, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = plane.transform.position - plane.transform.forward * coefficient + offset;
        transform.rotation = plane.transform.rotation;
    }
}
