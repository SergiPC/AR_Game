using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D myBody;
    Transform myTransform;

    public float speed = 10;
    public float jumpVelocity = 10;
    public Transform tagGround;
    public LayerMask playerMask;

    private bool grounded = false;

    void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myTransform = this.transform;
	}
	
	void FixedUpdate ()
    {
        grounded = Physics2D.Linecast(myTransform.position, tagGround.position, playerMask);

        Move(Input.GetAxisRaw("Horizontal"));
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
	}

    public void Move(float horizonInput)
    {
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizonInput * speed;
        myBody.velocity = moveVel;
    }

    public void Jump()
    {
        if(grounded)
            myBody.velocity += jumpVelocity * Vector2.up;
    }
}
