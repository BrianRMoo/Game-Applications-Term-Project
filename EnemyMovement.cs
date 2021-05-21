using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not used. Bassically ignores all physics and moves an object a distance toward another and when within that smaller distance does what you want
public class EnemyMovement : MonoBehaviour
{

    public PlayerMovement Player;
    public Transform enemyShotPoint;
    public GameObject enemyShot;
    public float maxDistance;
    private bool canShoot;
    public float timer;


    private void Start()
    {
        Player = GetComponent<PlayerMovement>();
        //to ensure that there is no null for player, which would happen due to using a prefab
        //break prefab only sometimes works
        if (Player == null)
        {
            Player = FindObjectOfType<PlayerMovement>();
        }
        if (enemyShot == null)
        {
            Debug.Log("Enemy shot found");
            //enemyShot = GameObject.Find("Laser");
            enemyShot = GameObject.FindObjectOfType<Laser>().gameObject;
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        if (!canShoot)
        {
            timer -= Time.deltaTime;

        }
        if (timer <= 0)
        {
            timer = 1;
            canShoot = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerRange") && canShoot)
        {
            ShootAtPlayer();
            canShoot = false;
        }

    }

    public void ShootAtPlayer()
    {
        Instantiate(enemyShot, enemyShotPoint.transform.position, enemyShotPoint.transform.rotation);
        //enemyShot.gameObject.SetActive(false);
    }
}