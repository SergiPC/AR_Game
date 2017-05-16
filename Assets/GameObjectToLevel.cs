using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectToLevel : MonoBehaviour {

    public GameObject linked_object;
    public bool block_rotation = false;
	// Use this for initialization
	void Awake ()
    {
    }
	

	void Update ()
    {
        if(linked_object.activeInHierarchy)
        {
            transform.position = linked_object.transform.position;
            transform.localPosition = new Vector3(transform.localPosition.x, 0.0f, transform.localPosition.z);
            if(!block_rotation)
            {
                transform.rotation = linked_object.transform.rotation;
                transform.localRotation = Quaternion.Euler(90.0f, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
            }
            
        }
        
    }
}
