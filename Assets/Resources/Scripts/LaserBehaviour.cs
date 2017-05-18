using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour {

    GameObject laser;
    public float spawn_rate = 1.0f;
    float laser_timer = 0.0f;
    bool active = false;
	// Use this for initialization
	void Start () {
        laser = transform.GetChild(0).gameObject;
        laser.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (LevelManager.current_level.GetState() == Level_states.IN_GAME)
        {
            if (laser_timer >= spawn_rate)
            {
                active = !active;
                laser.SetActive(active);
                laser_timer = 0.0f;
            }
            else
                laser_timer += Time.deltaTime;
        }
    }
}
