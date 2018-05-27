using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Entity pl, en;
    public Transform plPanel, enPanel;
    public float drop;
    public float dropSpeed;
    float y;
    public Image[] PA;
    public Sprite[] PASrc;
    void Start()
    {
        y = plPanel.position.y;
        drop =y-drop;
    }

    void Update()
    {
        if (!pl)
        { if (plPanel.position.y < y )     { plPanel.position += new Vector3(0f, (Time.deltaTime * dropSpeed), 0f ); } }
        else
        {
            if (plPanel.position.y >= drop ){ plPanel.position += new Vector3(0f, -(Time.deltaTime * dropSpeed) , 0f); }
            plPanel.Find("StatsAlly").GetComponent<Text>().text = pl.hp.ToString();
            plPanel.Find("StatsAlly2").GetComponent<Text>().text = pl.def.ToString();
            plPanel.Find("StatsAlly3").GetComponent<Text>().text = pl.deg.ToString();
        }

        if (!en)
        { if (enPanel.position.y < y)      { enPanel.position += new Vector3(0.0f, (Time.deltaTime * dropSpeed), 0f); } }
        else
        {
            if (enPanel.position.y >= drop) { enPanel.position += new Vector3(0.0f, -(Time.deltaTime * dropSpeed), 0f); }
            enPanel.Find("StatsAlly").GetComponent<Text>().text = en.hp.ToString();
            enPanel.Find("StatsAlly2").GetComponent<Text>().text = en.def.ToString();
            enPanel.Find("StatsAlly3").GetComponent<Text>().text = en.deg.ToString();
        }
        for (int i = 0; i < PA.Length; i ++) { PA[i].sprite = (i < GameManager.PA) ? PASrc[0]:PASrc[2]; }
    }
}
