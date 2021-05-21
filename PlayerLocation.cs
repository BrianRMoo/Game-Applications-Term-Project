using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLocation : MonoBehaviour
{

    public Text compass;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        compass.text = "Location\n";
        compass.text += "X: " + transform.position.x.ToString("0.00") + "\n";
        compass.text += "Y: " + transform.position.x.ToString("0.00") + "\n";
        compass.text += "Z: " + transform.position.x.ToString("0.00");
    }
}
