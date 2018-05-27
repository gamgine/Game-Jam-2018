using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Combat : MonoBehaviour {

    public bool fight;
    public float up;
    public float upSpeed;
    public Transform ground;
    public float gradient;
    Image img;
    float y;

	// Use this for initialization
	void Start () {

        y = ground.position.y;
        img = GameObject.Find("background").GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
        fight = GameObject.Find("Ui").GetComponent<UI>().fight;
        if (!fight)
        {
            if (ground.position.y > y) { ground.position += new Vector3(0f, -(Time.deltaTime * upSpeed), 0f); }
            if (img.color.a > 0) { img.color += new Color(0, 0, 0, -Time.deltaTime ); }
        }
        else
        {
            if (ground.position.y <= up) { ground.position += new Vector3(0f, (Time.deltaTime * upSpeed), 0f); }
            if (img.color.a < .55) { img.color += new Color(0, 0, 0, Time.deltaTime ); }
        }

    }
}
