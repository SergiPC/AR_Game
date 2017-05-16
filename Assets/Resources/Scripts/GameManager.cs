using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Players Scores
    public int[] player_scores = new int[4];
    public int num_players = 0;
    public bool[] player_playing = new bool[4];
    public static GameManager current;

    void Awake()
    {
        if (current == null)
            current = this;
        else
            Destroy(this);

    }

    void Start ()
    {
        for (int i = 0; i < 4; ++i)
            player_playing[i] = false;

    }

	void Update ()
    {
		
	}

    public void  ActivatePlayer(int player_num)
    {
        if(player_num < 4)
            player_playing[player_num] = true;
    }

    public void DeActivatePlayer(int player_num)
    {
        if (player_num < 4)
            player_playing[player_num] = false;
    }
}
