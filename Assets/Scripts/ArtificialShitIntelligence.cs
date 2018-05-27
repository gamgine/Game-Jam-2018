using UnityEngine;
using System.Collections;

public class ArtificialShitIntelligence : MonoBehaviour
{
    void Start(){}
    void Update()
    {
        if(!GameManager.player)
        {
            foreach (Entity el in GetComponents<Entity>())
            {
                if (el.player || GameManager.PA<=0) { continue; }//not ia not play or not plai if no pa
                foreach (Entity trig in el.triger)
                {
                    if (!trig.player) { continue; }//not att ia
                    Camera.main.GetComponent<Fight>().att = el;
                    Camera.main.GetComponent<Fight>().def = trig;
                    GameManager.PA -= 1;
                }
            }
            Camera.main.GetComponent<GameManagerAct>().Next();
        }
    }
}
