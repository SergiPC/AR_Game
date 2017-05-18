using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimatePlayerController : MonoBehaviour {

    public float maxSpeed = 5f;
    public float jumpForce = 250f;
    public bool grounded = false;
    public Transform tagGround;
    public LayerMask whatIsGround;
    public int player = 0;

    Rigidbody myBody;
    float groundRadius = 0.05f;
    string input_horizontal = "Horizontal01";
    string input_jump = "Jump01";
    public float respawn_time = 0.0f;
    float current_respawn_time = 0.0f;
    Renderer sprite;
    Collider g_col;
    bool alive = false;
    Vector3 ini_pos;
    bool won = false;
    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody>();
        sprite = GetComponent<Renderer>();
        g_col = GetComponent<Collider>();
        alive = true;
        won = false;
        ini_pos = transform.localPosition;
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

    void OnCollisionEnter(Collision col)
    {
        if((col.gameObject.CompareTag("Malus") && won == false) || col.gameObject.CompareTag("out"))
        {
            sprite.enabled = false;
            g_col.enabled = false;
            alive = false;
            current_respawn_time = 0.0f;
            Renderer[] child_c = GetComponentsInChildren<Renderer>();

            foreach (Renderer r in child_c)
            {
                r.enabled = false;
            }

        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            GameManager.current.PlayerWon(player - 1);
            myBody.velocity = Vector3.zero;
            won = true;
        }

    }

    void FixedUpdate ()
    {
        if(alive && !won)
        {
            Collider[] colliders = Physics.OverlapSphere(tagGround.position, groundRadius, whatIsGround);
            if (colliders.Length > 0)
                grounded = true;
            else
                grounded = false;
            float move = Input.GetAxis(input_horizontal);
            float yVel = transform.InverseTransformDirection(myBody.velocity).y;
            Vector3 vel = new Vector3((move * maxSpeed), yVel);
            myBody.velocity = transform.TransformDirection(vel);
            //myBody.velocity = new Vector3((move * maxSpeed), myBody.velocity.y);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("" + player) && won == false)
            Respawn();
        if (alive && !won)
        {
            // Jump.
            if (grounded && Input.GetButtonDown(input_jump))
            {
                myBody.AddForce(transform.up.normalized * jumpForce);
            }
        }

        if (!alive)
        {
            if(current_respawn_time >= respawn_time)
            {
                Respawn();
            }
            current_respawn_time += Time.deltaTime;
        }
    }

    public void Respawn ()
    {
        g_col.enabled = true;
        sprite.enabled = true;
        myBody.velocity = Vector3.zero;
        transform.localPosition = ini_pos;
        alive = true;
        won = false;
        Renderer[] child_c = GetComponentsInChildren<Renderer>(true);

        foreach (Renderer r in child_c)
        {
            r.enabled = true;
        }
    }
}
