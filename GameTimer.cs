using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Attached to the HUD GameObject
//Controls when the game ends, doesnt start until after the menu has been deactivated and the HUD object becomes active
public class GameTimer : MonoBehaviour
{
    //timer
    public static float timer = 60;

    //viewable timer text
    public Text TimerText;
    //player highscore text
    public Text highScoreText;
    //your current score
    public Text yourScoreText;

    public static bool playerKilled;

    [Header("Disable all but Scores")]
    public GameObject[] disableOverlay;
    [Header("Score Display")]
    public GameObject endGamePanel;
    // Use this for initialization
    void Start()
    {
    //disable the gameover ui 
        endGamePanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //start timer on update
        timer -= Time.deltaTime * 1;
        TimerText.text = timer.ToString("0");
        
        //if time is out or player died
        if (timer <= 0 || playerKilled)
        {
            TimerText.text = 0.ToString();
            
            //disable current onscreen ui
            for (int i = 0; i < disableOverlay.Length; i++)
            {

                disableOverlay[i].SetActive(false);
            }
            //engage gameover
            Invoke("EndGame", 5);
            endGamePanel.SetActive(true);
            highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
            yourScoreText.text = Score.actualScore.ToString();
           
            
        }
    }

    public void EndGame()
    {
        playerKilled = false;
        endGamePanel.SetActive(false);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("loading");
    }
}
