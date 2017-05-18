using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Players Scores
    public int[] player_scores = new int[4];
    public int num_players = 0;
    public bool[] player_playing = new bool[4];
    bool[] player_finished = new bool[4];
    public static GameManager current;
    public int round_num = 0;
    void Awake()
    {
        if (current == null)
            current = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }

    void Start ()
    {
        for (int i = 0; i < 4; ++i)
        {
            player_playing[i] = false;
            player_finished[i] = false;
            player_scores[i] = 0;
        }
    }

    public void  ActivatePlayer(int player_num)
    {
        if(!player_playing[player_num])
        {
            if (player_num < 4)
                player_playing[player_num] = true;
            num_players++;
        }
        
    }

    public void DeActivatePlayer(int player_num)
    {
        if (player_playing[player_num])
        {
            if (player_num < 4)
                player_playing[player_num] = false;
            num_players--;
        }
    }

    public void PlayerWon(int player_num)
    {
        int num_finished = 0;
        for (int i = 0; i < 4; ++i)
        {
            if (player_finished[i])
                num_finished++;
        }
        player_finished[player_num] = true;
        switch (num_finished)
        {
            case 0:
                player_scores[player_num] += 5;
                break;
            case 1:
                player_scores[player_num] += 3;
                break;
            case 2:
                player_scores[player_num] += 2;
                break;
            case 3:
                player_scores[player_num] += 1;
                break;
        }
        if (num_finished + 1 >= num_players)
        {
            if (round_num == 3)
            {
                LevelManager.current_level.Change_State(Level_states.FINISHED);
            }
            else
            {
                round_num++;
                LevelManager.current_level.Change_State(Level_states.SCORE);
                ResetLevel();
            }
            

        }
            
    }

    public void ResetLevel()
    {
        for (int i = 0; i < 4; ++i)
        {
            player_finished[i] = false;
        }
    }

    public void LoadScene()
    {
        if(num_players > 0 )
            SceneManager.LoadScene(1);
    }

    public void RetrunToMenu()
    {
        for (int i = 0; i < 4; ++i)
        {
            player_playing[i] = false;
            player_finished[i] = false;
            player_scores[i] = 0;
        }
        if (num_players > 0)
            SceneManager.LoadScene(0);
    }

    public int GetHigherScore()
    {
        int max_num = 0;
        int id = 0;
        for(int i = 0;i<4;i++)
        {
            if(max_num < player_scores[i])
            {
                id = i;
                max_num = player_scores[i];
            }
        }
        return id;
    }
}
