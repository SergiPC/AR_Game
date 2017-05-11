using UnityEngine;
using GamepadInput;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        //anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 w = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One, true);
        
        if(Input.GetKey(KeyCode.A))
        {
            w.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            w.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            w.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            w.y = -1;
        }

        if (GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.One))
        {
            // anim.SetTrigger("Attack");
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(movement.normalized* playerRigidbody.mass*4,ForceMode.Impulse);
        }
        
        Move(w.y, w.x);
        //Turning();
        Animating(w.x, w.y);
    }

    void Move(float h,float v)
    {
        movement = new Vector3(v, 0.0f, h);
        movement = transform.parent.localToWorldMatrix * movement;
        movement = movement.normalized * speed * Time.fixedDeltaTime;

        
        playerRigidbody.velocity = movement;

        if (movement.magnitude > 0.01f)
        {
            transform.eulerAngles = new Vector3 (transform.eulerAngles.x, Mathf.Atan2 (h, v) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h,float v)
    {
        bool walking = h != 0f || v != 0f;
        //anim.SetBool("IsWalking", walking);
    }
}
