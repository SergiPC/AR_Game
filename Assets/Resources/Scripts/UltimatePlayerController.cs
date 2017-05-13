﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimatePlayerController : MonoBehaviour {

    public float maxSpeed = 5f;
    public float jumpForce = 250f;
    public bool grounded = false;
    public Transform tagGround;
    public LayerMask whatIsGround;
    public int player = 0;

    Rigidbody2D myBody;
    float groundRadius = 0.1f;
    string input_horizontal = "Horizontal01";
    string input_jump = "Jump01";

    // Use this for initialization
    void Start () {
        myBody = this.GetComponent<Rigidbody2D>();

        switch (player)
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

    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(tagGround.position, groundRadius, whatIsGround);

        float move = Input.GetAxis(input_horizontal);

        myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);
	}

    // Update is called once per frame
    void Update()
    {
        // Jump.
        if(grounded && Input.GetButtonDown(input_jump))
        {
            myBody.AddForce(new Vector2(0, jumpForce));
        }
    }
}