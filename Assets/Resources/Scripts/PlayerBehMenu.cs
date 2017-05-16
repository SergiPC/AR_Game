using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehMenu : MonoBehaviour {

    public int player = 0;
    string input_horizontal = "Horizontal01";
    string input_jump = "Jump01";
    GameObject child;
    bool active = false;
    // Use this for initialization
    void Start()
    {
        child = transform.GetChild(0).gameObject;
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

    // Update is called once per frame
    void Update ()
    {
        bool pl_input = Input.GetButtonDown(input_horizontal);
        bool pl_input2 = Input.GetButtonDown(input_jump);

        if(pl_input || pl_input2)
        {
            if(!active)
            {
                GameManager.current.ActivatePlayer(player - 1);
                child.SetActive(true);
                active = true;
            }
            else
            {
                GameManager.current.DeActivatePlayer(player - 1);
                child.SetActive(false);
                active = false;
            }
            
        }
    }
}
