﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fight : MonoBehaviour {

    public bool fight;
    public float up;
    public float upSpeed;
    public Transform ground;
    public GameObject combattant1;
    public GameObject combattant2;
    Entity com1;
    Entity com2;
    Image img;
    public float time = 3.0f;
    public bool turn;
    float x;
    float y;

    void Start()
    {
        //x = combattant1.transform.position.x;
        y = ground.position.y;
        img = transform.parent.Find("background").GetComponent<Image>();
    }

    void Update()
    {
        if (!GameManager.fight)
        {
            if (ground.position.y > y) { ground.position += new Vector3(0f, -(Time.deltaTime * upSpeed), 0f); }
            if (img.color.a > 0) { img.color += new Color(0, 0, 0, -Time.deltaTime); }
        }
        else
        {
            if (ground.position.y <= up) { ground.position += new Vector3(0f, (Time.deltaTime * upSpeed), 0f); }
            if (combattant1.transform.position.x < 70) { combattant1.transform.position += new Vector3((Time.deltaTime * upSpeed), 0f, 0f); }
            if (combattant2.transform.position.x > 250) { combattant2.transform.position += new Vector3(-(Time.deltaTime * upSpeed), 0f, 0f); }
            if (img.color.a < .55) { img.color += new Color(0, 0, 0, Time.deltaTime); }

            if (!(ground.position.y <= up && img.color.a < .55 && combattant2.transform.position.x > 250 && combattant1.transform.position.x < 70))
            {
                time -= Time.deltaTime;
                if (time < 0 && turn == true)
                {
                    int dommages = com2.def - com1.deg;
                    Debug.Log(dommages);
                    com2.hp -= dommages;

                }

            }
        }

    }
    public void StartFight(Entity el1, Entity el2)
    {
        if (!GameManager.fight)
        {
            com1 = el1;
            com2 = el2;
            combattant1 = Instantiate(el1.sprite, new Vector3(-63, 0, 0), Quaternion.identity);
            combattant1.transform.SetParent(ground);
            combattant2 = Instantiate(el2.sprite, new Vector3(371, 0, 0), Quaternion.identity);
            combattant2.transform.SetParent(ground);
            combattant2.transform.eulerAngles = new Vector3(0, 180, 0);
            GameManager.fight = true;
        }
    }
}