using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChecker : MonoBehaviour {

    public float gravity = 9.81f;
    Vector3 last_transform;
	// Use this for initialization
	void Start () {
        last_transform = transform.up;

    }

    void FixedUpdate()
    {
        if(transform.up != last_transform)
        { 
            Physics.gravity = (new Vector3(transform.up.normalized.x, transform.up.normalized.y, transform.up.normalized.z)) * -gravity;
            last_transform = transform.up;
        }
        
    }
}
