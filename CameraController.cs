using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject top, fps, behind;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            //default
            top.SetActive(true);
            fps.SetActive(false);
            behind.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.F2))
        {
            //cockpit-ish view
            top.SetActive(false);
            fps.SetActive(true);
            behind.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.F3))
        {
            //third person behind ship view
            top.SetActive(false);
            fps.SetActive(false);
            behind.SetActive(true);
        }
    }
}
