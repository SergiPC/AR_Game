using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTurretBehaviour : MonoBehaviour {


    public GameObject Bullet;
    public GameObject Bullet_Emitter;

    public float Bullet_Forward_Force;
    Vector3 direction;
    public float max_time = 1.0f;
    float timer = 0.0f;

    MarkerDetectionScript target_script;
    // Use this for initialization
    void Start () {
        target_script = transform.parent.gameObject.GetComponent<MarkerDetectionScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(target_script.markerDetected())
        {
            Debug.Log("ACTIVE");
            if (timer > max_time)
            {
                timer = 0.0f;
                
                ShootBullet();
            }
            else
                timer += Time.deltaTime;
        }
        
	}


    void ShootBullet()
    {
        //The Bullet instantiation happens here.
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
        //Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
        Debug.Log("SHooting Stars");
        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        
        direction = Bullet_Emitter.transform.forward;
        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
        Temporary_RigidBody.AddForce(direction.normalized * Bullet_Forward_Force);

        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
        Destroy(Temporary_Bullet_Handler, 10.0f);
    }
}
