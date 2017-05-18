using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFriend : MonoBehaviour {

    public GameObject friend;

	void OnEnable () {
        friend.SetActive(true);

    }


    void OnDisable()
    {
        if(friend != null)
            friend.SetActive(false);
    }

}
