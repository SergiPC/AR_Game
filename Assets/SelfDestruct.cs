using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float max_timer = 1.5f;
    float timer = 0.0f;
	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if(timer> max_timer*0.3f)
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (timer > max_timer)
        {
            timer = 0.0f;
            Destroy(gameObject);
        }
        else
            timer += Time.deltaTime;
    }
}
