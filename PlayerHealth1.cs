using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Controls the life of the player
public class PlayerHealth1 : MonoBehaviour {

    public int playerHealthValue = 100;
    private int health;
    public GameObject playerDeathFx;
    public Slider healthBar;

    private void Start()
    {
        //Make sure that anytime the game start the player is at full health
        health = playerHealthValue;
        healthBar.maxValue = 100;
        healthBar.minValue = 0;
    }
    //make sure player health is update every frame
    private void Update()
    {
        healthBar.value = playerHealthValue;
       //if player health ever reaches 0 or lower end game
      if(health <= 0)
        {
            //GameOver

            //play deathFX
            Instantiate(playerDeathFx, transform.position, transform.rotation);
            //Reset Level
            SceneManager.LoadScene("main", LoadSceneMode.Single);
        }
    }
    
    //change health on collision
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            HealthValueChange();
        }
    }
    
    //health change function -> lower it by one int each time it is called and set new health value
    public void HealthValueChange()
    {
        healthBar.value -= 1;
        healthBar.value = health;
    }
}
