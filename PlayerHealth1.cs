using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Not Fully working yet...
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
    private void Update()
    {
        healthBar.value = playerHealthValue;

      if(health <= 0)
        {
            //GameOver

            //playv deathFX
            Instantiate(playerDeathFx, transform.position, transform.rotation);
            //Reset Level
            SceneManager.LoadScene("main", LoadSceneMode.Single);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            HealthValueChange();
        }
    }

    public void HealthValueChange()
    {
        healthBar.value -= 1;
        healthBar.value = health;
    }
}
