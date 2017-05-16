using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public GameObject Bullet;

    public float bullet_force = 100f;
    public float bullet_cooldown = 3.0f;
    public float bullet_die_timer = 1.0f;
    float bullet_timer = 0.0f;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (bullet_timer >= bullet_cooldown)
        {
            FireBullet();
            bullet_timer = 0.0f;
        }
        else
            bullet_timer += Time.deltaTime;

    }

    void FireBullet()
    {
        if(Bullet != null )
        {
            GameObject tmp_bullet = Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
            Rigidbody bullet_rigid = tmp_bullet.GetComponent<Rigidbody>();

            bullet_rigid.AddForce(gameObject.transform.right * bullet_force);
            Destroy(tmp_bullet, bullet_die_timer);
        }
    }
}
