using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeLocalScale : MonoBehaviour {

    public float increaseAmount;
	
	void Start () {

        
	}
	void Update () {
        //Takes the given objects scale and multiplies it by a Vector of ones * a seconds of increased amount
        transform.localScale += Vector3.one * Time.deltaTime * increaseAmount;
	}
}
