using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    void Update()
    {
    //take the transform of the object and have it look at the camera
        transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }
}
