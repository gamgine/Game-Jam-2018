using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool player = false;
    public static bool fight = false;
    public static int PA = 10;
}
public class GameManagerAct : MonoBehaviour
{
    void Update(){ if (GameManager.PA <= 1) { this.Next(); } }
    public void Next() { GameManager.player = !GameManager.player; GameManager.PA = 10; }
}