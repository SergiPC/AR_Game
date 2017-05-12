using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour {

    public float max_distance_offset = 10.0f;
    public bool going_up = true;
    public float speed = 10.0f;
    float initial_y = 0.0f;
	// Use this for initialization
	void Start () {
        initial_y = gameObject.transform.position.y;

    }

    void OnEnable()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, initial_y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (going_up)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, initial_y + max_distance_offset, gameObject.transform.position.z), speed * Time.deltaTime);

            if ((initial_y + max_distance_offset) - gameObject.transform.position.y < 0.01f)
            {
                going_up = false;
            }
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, initial_y - max_distance_offset, gameObject.transform.position.z), speed * Time.deltaTime);

            if (gameObject.transform.position.y - (initial_y - max_distance_offset) < 0.01f)
            {
                going_up = true;
            }
        }
    }
}
