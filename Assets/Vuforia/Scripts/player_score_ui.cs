using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_score_ui : MonoBehaviour {

    Text score = null;
    Image fill_image = null;
    public int player_num = 0;
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
    void OnEnable ()
    {
        score = GetComponentInChildren<Text>(true);
        fill_image = GetComponentsInChildren<Image>(true)[1];
        int score_ = GameManager.current.player_scores[player_num - 1];
        score.text = "" + score_;
        fill_image.fillAmount = (float)(score_) / 20f;
    }
    
	// Update is called once per frame
	void Update ()
    {
		
	}
}
