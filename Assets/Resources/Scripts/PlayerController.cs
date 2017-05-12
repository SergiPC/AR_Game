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
    public int player = 0;

    string input_horizontal = "Horizontal01";
    string input_jump = "Jump01";
    private bool grounded = false;

    void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myTransform = this.transform;

        switch(player)
        {
            case 1:
                input_horizontal = "Horizontal01";
                input_jump = "Jump01";
                break;
            case 2:
                input_horizontal = "Horizontal02";
                input_jump = "Jump02";
                break;
            case 3:
                input_horizontal = "Horizontal03";
                input_jump = "Jump03";
                break;
            case 4:
                input_horizontal = "Horizontal04";
                input_jump = "Jump04";
                break;
        }
	}
	
	void FixedUpdate ()
    {
        grounded = Physics2D.Linecast(myTransform.position, tagGround.position, playerMask);

        Move(Input.GetAxisRaw(input_horizontal));
        if(Input.GetButtonDown(input_jump))
        {
            Jump();
        }
	}

    public void Move(float horizonInput)
    {
        Vector2 moveVel = myBody.velocity;
        moveVel = new Vector2(transform.right.x, transform.right.y) * horizonInput * speed;
        myBody.velocity = moveVel;
    }

    public void Jump()
    {
        if(grounded)
            myBody.velocity += jumpVelocity * new Vector2(transform.up.x, transform.up.y);
    }
}
