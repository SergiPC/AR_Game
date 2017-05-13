using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectToLevel : MonoBehaviour {

    public GameObject linked_object;
    float local_z = 0.0f;
	// Use this for initialization
	void Awake ()
    {
        local_z = 0.0f;

    }
	

	void Update ()
    {
        transform.position = linked_object.transform.position;
        transform.localPosition = new Vector3 (transform.localPosition.x, 0.0f, transform.localPosition.z);
	}
}
