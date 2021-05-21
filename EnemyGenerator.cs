using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generates  the enemy prefab which is set to a specific amount
//Makes sure that there is never too few enemies or basically there are 25 enemies per generator
//100 or so at a time was max that I could handle
public class EnemyGenerator : MonoBehaviour {

    public Transform spawnPoint;
    public GameObject[] enemy;
    private int enemySelector;
    public int maxEnemies;
    public static int currentEnemies;

    private void Start()
    {
        currentEnemies = 0;
        
    }
    private void Update()
    {
        enemySelector = Random.Range(0, enemy.Length);
       
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(currentEnemies < maxEnemies)
        {
            //Create an enemy from the array at the specified spawn point
           Instantiate(enemy[enemySelector], new Vector3(spawnPoint.position.x, 0, spawnPoint.position.z), spawnPoint.rotation);            
        }
        if(currentEnemies >= maxEnemies)
        {
            currentEnemies = maxEnemies;
        }
    }
}
