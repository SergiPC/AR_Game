using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFriend : MonoBehaviour {

    public GameObject friend;
	// Use this for initialization
	void OnEnable () {
        friend.SetActive(true);

    }

    // Use this for initialization
    void OnDisable()
    {
        friend.SetActive(false);
    }

}
