using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour {

    public GameObject target;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            target.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            target.SetActive(false);
        }
    }
}
