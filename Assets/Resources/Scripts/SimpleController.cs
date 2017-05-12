using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPhysics))]
public class SimpleController : MonoBehaviour {

    // Player Handling.
    public float gravity = 1;
    public float speed = 8;
    public float acceleration = 20;
    public float jumpHeight = 12;
    public float currentGravity = 1;
    public bool grounded;

    private float currentSpeed;
    private float targetSpeed;
    private Vector2 amountToMove;

    private PlayerPhysics playerPhysics;

	// Use this for initialization.
	void Start () {
        playerPhysics = GetComponent<PlayerPhysics>();
        grounded = false;
	}
	
	// Update is called once per frame.
	void Update () {
        targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
        currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

        if (grounded == true)
        {
            amountToMove.y = 0;
            currentGravity = 0;

            // Jump.
            if (Input.GetButtonDown("Jump"))
            {
                amountToMove.y = jumpHeight;
            }
        }
        if (grounded == false)
        {
            if (currentGravity == 0)
                currentGravity = gravity;
        }

        amountToMove.x = currentSpeed;
        amountToMove.y -= currentGravity * Time.deltaTime;
        playerPhysics.Move(amountToMove * Time.deltaTime);
    }

    // Increase n towards target by speed.
    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
            return n;
        else
        {
            float dir = Mathf.Sign(target - n); // n must be increased or decreased to get closer to target.
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target; // if n has now passed target then return target, otherwise return n.
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
