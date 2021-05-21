using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controls all main menu functions
public class MainMenu : MonoBehaviour
{

    public GameObject menuCam;
    public GameObject mainGameCamera;
    public GameObject boostPanel;
    public GameObject movementPanel;
    public GameObject firePanel;
    
    public Text highScoreText;

    //will generate on top of the game area, mainmenu is part of everything

    //what to deactivate to show the main menu and activate after the game starts
    public GameObject[] deactivate;
    public GameObject menu;

    private void Start()
    {
        mainGameCamera.SetActive(false);
        menuCam.SetActive(true);
        for (int i = 0; i < deactivate.Length; i++)
        {
            deactivate[i].SetActive(false);
        }
        if (!PlayerPrefs.HasKey("Tutorial"))
        {

            PlayerPrefs.SetInt("Tutorial", 0);
            PlayerPrefs.Save();
        }
        if(!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
            PlayerPrefs.Save();
        }
        else
        {
            highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
        }
        
    }

    public void PlayGame()
    {
        for (int i = 0; i < deactivate.Length; i++)
        {
            deactivate[i].SetActive(true);
            
        }
        var cameraController = FindObjectOfType<CameraController>();
        mainGameCamera.SetActive(true);
        movementPanel.SetActive(false);
        firePanel.SetActive(false);
        boostPanel.SetActive(false);
        menu.SetActive(false);
        menuCam.SetActive(false);
    }
}
