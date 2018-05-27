using UnityEngine;
using System.Collections;

public class ArtificialShitIntelligence : MonoBehaviour
{
    public GameObject combatsys;
    float time;
    void Update()
    {
        if(!GameManager.player)
        {
            if (time > 5)
            {
                foreach (GameObject el in GameObject.FindGameObjectsWithTag("Player"))
                {
                    Entity elE = el.GetComponent<Entity>();
                    if (elE.player || GameManager.PA <= 0) { continue; }//not ia not play or not plai if no pa
                    foreach (Entity trig in elE.triger)
                    {
                        if (!trig.player) { continue; }//not att ia
                        combatsys.GetComponent<Fight>().StartFight(elE, trig);
                        GameManager.PA -= 1;
                    }
                }
                Camera.main.GetComponent<GameManagerAct>().Next();
            }
            time += Time.deltaTime;
        }
    }
}
