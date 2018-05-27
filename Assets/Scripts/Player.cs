using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UI Ui;
    public GameObject select;
    public GameObject combatsys;
    void Start () {}
	void Update ()
    {
        if (GameManager.player)
        {
            if (Input.GetMouseButtonDown(0))//select
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore))
                {
                    if (!select && hit.transform.gameObject.tag == "Player" && hit.transform.gameObject.GetComponent<Entity>().player)
                    {
                        select = hit.transform.gameObject;
                        Ui.pl = select.GetComponent<Entity>();
                    }
                    else if (select) { select = null; }//unselect
                }
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore))
                {
                    if (hit.transform.gameObject.tag == "Player" && !hit.transform.gameObject.GetComponent<Entity>().player)
                    {
                        Ui.en = hit.transform.GetComponent<Entity>();
                        if (Input.GetMouseButtonDown(1) && Vector3.Distance(select.transform.position, hit.transform.position)<= Ui.en.shootRange)// in range & m1
                        { combatsys.GetComponent<Fight>().StartFight(Ui.en,select.GetComponent<Entity>()); GameManager.PA -=1; }//att 
                        else if (Input.GetMouseButtonDown(1) && select) { select.GetComponent<Entity>().MvTo(hit.point); GameManager.PA -= 3; }//mv
                    }
                    else
                    {
                        Ui.en = null;
                        // pa for act
                        if (Input.GetMouseButtonDown(1) && select) { select.GetComponent<Entity>().MvTo(hit.point); GameManager.PA -=3; }//action
                    }
                }
            }
        }
        else { select = null; Ui.pl = null; }
    }
}
