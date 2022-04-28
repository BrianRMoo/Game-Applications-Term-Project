using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour {
    //get the object(player) 
    public GameObject target;

    //create a zone that the enemy ships have to detect the player object
    private void OnTriggerStay(Collider other)
    {        
        if(other.gameObject.CompareTag("Target"))
        {
            target.SetActive(true);
        }
    }

    //detec whether the player is in range or not
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            target.SetActive(false);
        }
    }
}
