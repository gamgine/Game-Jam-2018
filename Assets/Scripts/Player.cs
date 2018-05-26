using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject select;
	void Start () {}
	void Update ()
    {
        if (GameManager.player)
        {
            if (Input.GetMouseButtonDown(0))//select
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                {
                    if (!select && hit.transform.gameObject.tag == "Player")
                    {
                        if (hit.transform.gameObject.GetComponent<Entity>().player) { select = hit.transform.gameObject; }
                        else { }
                    }
                }
            }
            else if (Input.GetMouseButtonDown(1) && select)//action
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                { select.GetComponent<Entity>().MvTo(hit.point); }
            }
        }
    }
}
