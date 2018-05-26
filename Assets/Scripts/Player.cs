using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UI Ui;
    public GameObject select;
    void Start () {}
	void Update ()
    {
        if (GameManager.player || true)
        {
            if (Input.GetMouseButtonDown(0))//select
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                {
                    if (!select && hit.transform.gameObject.tag == "Player" && hit.transform.gameObject.GetComponent<Entity>().player)
                    {
                        select = hit.transform.gameObject;
                        Ui.pl = select.GetComponent<Entity>();
                    }
                }
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                {
                    if (hit.transform.gameObject.tag == "Player" && !hit.transform.gameObject.GetComponent<Entity>().player)
                    {
                        Ui.en = hit.transform.GetComponent<Entity>();
                        if (Input.GetMouseButtonDown(1)) { Debug.Log("combat"); }//action //check dist
                    }
                    else
                    {
                        Ui.en = null;
                        if(Input.GetMouseButtonDown(1)) { select.GetComponent<Entity>().MvTo(hit.point); }//action
                    }
                }
            }
        }
        else { select = null; Ui.pl = null; }
    }
}
