using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Entity pl, en;
    public Transform plPanel, enPanel;
    float z;
    public float drop;
    public float dropSpeed;
    void Start()
    {
        z = plPanel.position.z;
        drop =z-drop;
    }

    void Update()
    {
        if (!pl)
        { if (plPanel.position.z < z){ plPanel.position += new Vector3(0.0f, 0.0f, (Time.deltaTime*dropSpeed) ); } }
        else
        {
            if (plPanel.position.z >= drop   ){
                    plPanel.position += new Vector3(0.0f, 0.0f, -(Time.deltaTime*dropSpeed) ); }
            plPanel.Find("StatsAlly").GetComponent<Text>().text = pl.hp.ToString();
            plPanel.Find("StatsAlly2").GetComponent<Text>().text = pl.def.ToString();
            plPanel.Find("StatsAlly3").GetComponent<Text>().text = pl.deg.ToString();
        }

        if (!en)
        { if (enPanel.position.z < z) { enPanel.position += new Vector3(0.0f, 0.0f, (Time.deltaTime * dropSpeed)); } }
        else
        {
            if (enPanel.position.z >= drop) { enPanel.position += new Vector3(0.0f, 0.0f, -(Time.deltaTime * dropSpeed)); }
            enPanel.Find("StatsAlly").GetComponent<Text>().text = en.hp.ToString();
            enPanel.Find("StatsAlly2").GetComponent<Text>().text = en.def.ToString();
            enPanel.Find("StatsAlly3").GetComponent<Text>().text = en.deg.ToString();
        }
    }
}
