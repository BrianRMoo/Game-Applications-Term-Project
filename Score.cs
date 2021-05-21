using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Handles all scoring 
public class Score : MonoBehaviour {
    private int scoringBonus = 500;
    public Text scoreV;
    public static int actualScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreV.text = actualScore.ToString();
        
        if(actualScore >= scoringBonus)
        {
            scoringBonus += 500;
            GameTimer.timer += 30;
        }    
        if(GameTimer.playerKilled)
        {
            if(actualScore > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", actualScore);
                PlayerPrefs.Save();
            }
        }
	}
}
