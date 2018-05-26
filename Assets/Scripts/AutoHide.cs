using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHide : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        foreach (MeshRenderer el in gameObject.GetComponentsInChildren<MeshRenderer>()) {el.enabled = false; }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
