using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour {

    public float max_distance_offset = 10.0f;
    public bool going_up = true;
    public float speed = 10.0f;
    Vector3 initial_pos;
	// Use this for initialization
	void Start () {
        initial_pos = gameObject.transform.localPosition;

    }

    void OnEnable()
    {
        initial_pos = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.current_level.GetState() == Level_states.IN_GAME)
        { 
            if (going_up)
            {
            
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, initial_pos + Vector3.up * max_distance_offset, speed * Time.deltaTime);

                if (Vector3.Distance(gameObject.transform.localPosition, initial_pos + Vector3.up * max_distance_offset) < 0.01f)
                {
                    going_up = false; 
                }
            }
            else
            {
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, initial_pos + Vector3.up * -max_distance_offset, speed * Time.deltaTime);

                if (Vector3.Distance(gameObject.transform.localPosition, initial_pos + Vector3.up * -max_distance_offset) < 0.01f)
                {
                    going_up = true;
                }
            }
        }
        else if(LevelManager.current_level.GetState() == Level_states.STARTING)
            initial_pos = gameObject.transform.localPosition;
    }
}
