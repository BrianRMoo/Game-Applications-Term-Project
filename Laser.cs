using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject playerDeathFx;
    public PlayerMovement Player;
    public int MoveSpeed = 1;
    public int MaxDist = 20;
    public float MinDist = .5f;
    public AudioSource sound;
    public AudioClip deathSoundFx;
    //[Header("Disable or set to false in VS before build")]
    //public bool cancelPlayerDeath;

    void Start()
    {
        sound = GetComponent<AudioSource>();

        Player = GetComponent<PlayerMovement>();
        if (Player == null)
        {
            Player = FindObjectOfType<PlayerMovement>();
        }
    }

    void Update()
    {
        transform.localScale -= Vector3.one * Time.deltaTime;
        if(transform.localScale.x <= 0)
        {
            gameObject.SetActive(false);
        }
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.LookAt(Player.transform.position);

        if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")/* && !cancelPlayerDeath*/)
        {
            //Debug.Log("Collision on Laser: tag name Player" + collision.gameObject.name);

            Instantiate(playerDeathFx, transform.position, transform.rotation);
            Invoke("KillPlayer", 5);
            collision.gameObject.SetActive(false);
            GameTimer.playerKilled = true;
            sound.PlayOneShot(deathSoundFx);


        }
        if (collision.gameObject.CompareTag("PlayerShot")/* && cancelPlayerDeath*/)
        {
            //Debug.Log("Collision on Laser tag name Player shot:" + collision.gameObject.name);
            this.gameObject.SetActive(false);
            Instantiate(playerDeathFx, transform.position, transform.rotation);
            Score.actualScore += 15;
            sound.PlayOneShot(deathSoundFx);
        }
    }
    public void KillPlayer()
    {
        CancelInvoke("KillPlayer");

    }
}
