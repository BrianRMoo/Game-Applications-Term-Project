using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {
    private float emulateLoad;
    private float loadAmount = 1;
    public Slider loadSlider;
    public GameObject panelPosition;
    private float min;
    private float max;
    //Loads the main scene in the background as this scene plays
        
	// Use this for initialization
	void Start () {
        panelPosition.transform.position = new Vector3(Screen.width / 2, transform.position.y, transform.position.z);
        loadSlider = GetComponent<Slider>();
        loadSlider.minValue = 0;
        loadSlider.maxValue = 100;
        min = loadSlider.minValue;
        max = loadSlider.maxValue;
        
	}
	
	// Update is called once per frame
	void Update () {
        emulateLoad = Random.Range(1, 11);
        if(emulateLoad % 2 == 0)
        {
            loadAmount += .5f;
        }
        else
        {
            loadAmount += .025f;
        }
        loadSlider.value = 1 * Time.deltaTime + loadAmount;
        if(loadSlider.value >= 100)
        {
            SceneManager.LoadScene(1);
                        
            
        }
	}
}
