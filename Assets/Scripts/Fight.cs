using System.Collections;
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
    Animator anim;
    Animator anim2;
    public float time;
    public bool turn=true;
    public bool end = false;
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
			
			if (combattant1&&combattant1.transform.position.y > -100) { combattant1.transform.position += new Vector3(0f, -(Time.deltaTime * upSpeed), 0f); }
			else if(combattant1){Destroy(combattant1);}
            if (combattant2&&combattant2.transform.position.y > -100) { combattant2.transform.position += new Vector3(0f,-(Time.deltaTime * upSpeed), 0f); }
			else if(combattant2){Destroy(combattant2);}
        }
        else
        {
            if (ground.position.y <= up) { ground.position += new Vector3(0f, (Time.deltaTime * upSpeed), 0f); }
            if (combattant1.transform.position.x < 70) { combattant1.transform.position += new Vector3((Time.deltaTime * upSpeed), 0f, 0f); }
            if (combattant2.transform.position.x > 250) { combattant2.transform.position += new Vector3(-(Time.deltaTime * upSpeed), 0f, 0f); }
            if (img.color.a < .55) { img.color += new Color(0, 0, 0, Time.deltaTime); }

            if (!(ground.position.y <= up && img.color.a < .55 && combattant2.transform.position.x > 250 && combattant1.transform.position.x < 70))
            {
                anim = combattant1.GetComponent<Animator>();
                anim2 = combattant2.GetComponent<Animator>();

                time -= Time.deltaTime;
                if (time < 0 && end == true)
                {
                    anim.SetBool("attack", false);
                    anim2.SetBool("attack", false);
					turn=true;
					time = 3;
					end = false;
                    GameManager.fight = false;
                }
                else if (time < 0 && turn == true) //nop here
                {
                    int dommages = com1.deg - com2.def;
                    if (dommages < 0) { dommages = 0; }
					Debug.Log("dm1 "+dommages);
                    com2.Damages(dommages);
                    anim.SetBool("attack", true);
                    time = 2f;
                    turn = false;
                }             
                else if (time < 0 && turn == false)
                {
                    int dommages = com2.deg - com1.def;
                    if (dommages < 0) { dommages = 0; }
                    Debug.Log("dm2 "+dommages);
                    com1.Damages(dommages);
                    anim2.SetBool("attack", true);
                    time = 2.0f;
                    end = true;
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
