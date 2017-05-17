using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Level_states
{
    STARTING,
    PLACE_TRAPS,
    IN_GAME,
    SCORE,
    FINISHED
}

public class LevelManager : MonoBehaviour {

    public int round_num = 0;
    bool[] player_playing = new bool[4];
    bool[] player_finished = new bool[4];
    GameObject place_traps;
    public Text place_timer = null;
    GameObject round_score;
    GameObject ui_in_game;
    public Text in_game_text = null;
    public static LevelManager current_level = null;
    float level_time = 180.0f;
    GameObject[] player = new GameObject[4];
    float timer = 0.0f;

    Level_states current_state = Level_states.STARTING;

    void Awake()
    {
        current_level = this;
        //Getting All the data
        player_playing = GameManager.current.player_playing;
        place_traps = GameObject.FindGameObjectWithTag("place_traps");
        place_timer = place_traps.GetComponentInChildren<Text>(true);
        place_traps.SetActive(false);
        round_score = GameObject.FindGameObjectWithTag("round_score");
        round_score.SetActive(false);
        ui_in_game = GameObject.FindGameObjectWithTag("ui_in_game");
        in_game_text = ui_in_game.GetComponentInChildren<Text>(true);
        ui_in_game.SetActive(false);
        player[0] = GameObject.FindGameObjectWithTag("Player01");
        player[1] = GameObject.FindGameObjectWithTag("Player02");
        player[2] = GameObject.FindGameObjectWithTag("Player03");
        player[3] = GameObject.FindGameObjectWithTag("Player04");

        player[0].GetComponent<UltimatePlayerController>().enabled = false;
        player[1].GetComponent<UltimatePlayerController>().enabled = false;
        player[2].GetComponent<UltimatePlayerController>().enabled = false;
        player[3].GetComponent<UltimatePlayerController>().enabled = false;

        round_num = GameManager.current.round_num;
        current_state = Level_states.STARTING;
    }

    void Start()
    {
        for(int i = 0;i < 4;i++)
        {
            player_playing[i] = GameManager.current.player_playing[i];
        }
    }

    void Update()
    {
        switch (current_state)
        {
            case Level_states.STARTING:
                OnStart();
                break;
            case Level_states.PLACE_TRAPS:
                OnTrapTime();
                break;
            case Level_states.IN_GAME:
                OnInGame();
                break;
            case Level_states.SCORE:
                OnScore();
                break;
            case Level_states.FINISHED:
                OnScore();
                break;
        }
        timer += Time.deltaTime;
    }

    void OnStart()
    {
        for (int i = 0; i < 4; i++)
        {
            if (player_playing[i])
            {
                player[i].SetActive(true);
                Debug.Log("ACtivating player " + i);
            }
            else
                player[i].SetActive(false);
        }
        if(round_num == 0)
            Change_State(Level_states.IN_GAME);
        else
            Change_State(Level_states.PLACE_TRAPS);
    }
    public Level_states GetState()
    {
        return current_state;
    }
    public void Change_State(Level_states new_state)
    {
        OnChangeState(new_state);
        current_state = new_state;
    }

    void OnChangeState(Level_states new_state)
    {
        switch (new_state)
        {
            case Level_states.STARTING: OnStart();
                break;
            case Level_states.PLACE_TRAPS: place_traps.SetActive(true);
                break;
            case Level_states.IN_GAME:
                ui_in_game.SetActive(true);
                player[0].GetComponent<UltimatePlayerController>().enabled = true;
                player[1].GetComponent<UltimatePlayerController>().enabled = true;
                player[2].GetComponent<UltimatePlayerController>().enabled = true;
                player[3].GetComponent<UltimatePlayerController>().enabled = true;
                break;
            case Level_states.SCORE: round_score.SetActive(true);
                break;
            case Level_states.FINISHED:
                break;
        }
        switch (current_state)
        {
            case Level_states.STARTING:
                break;
            case Level_states.PLACE_TRAPS:
                place_traps.SetActive(false);
                break;
            case Level_states.IN_GAME:
                player[0].GetComponent<UltimatePlayerController>().enabled = false;
                player[1].GetComponent<UltimatePlayerController>().enabled = false;
                player[2].GetComponent<UltimatePlayerController>().enabled = false;
                player[3].GetComponent<UltimatePlayerController>().enabled = false;
                ui_in_game.SetActive(false);
                break;
            case Level_states.SCORE:
                round_score.SetActive(false);
                break;
            case Level_states.FINISHED:
                break;
        }
        timer = 0.0f;
    }

    void OnTrapTime()
    {
        float time = 10 - timer;
        int seconds = Mathf.FloorToInt(time);
        int miliseconds = (int)((time - (float)seconds) * 1000f);
        if (miliseconds < 100)
            place_timer.text = "0" + seconds + ":0" + miliseconds;
        else if (miliseconds < 10)
            place_timer.text = "0" + seconds + ":00" + miliseconds;
        else
            place_timer.text = "0" + seconds + ":" + miliseconds;
        if (timer > 10)
            Change_State(Level_states.IN_GAME);
    }

    void OnInGame()
    {
        float time = level_time - timer;
        int seconds = Mathf.FloorToInt(time);
        int miliseconds = (int)((time - (float)seconds) * 1000f);
        if (miliseconds < 100)
            in_game_text.text = seconds + ":0" + miliseconds;
        else if (miliseconds < 10)
            in_game_text.text = seconds + ":00" + miliseconds;
        else
            in_game_text.text = seconds + ":" + miliseconds;
        if (timer > level_time)
            Change_State(Level_states.SCORE);
    }

    void OnScore()
    {
        if (timer > 20f)
            GameManager.current.LoadScene();
    }
}
