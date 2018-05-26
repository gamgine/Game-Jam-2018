using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
    public int hp, deg, def;
    public bool player;
    public float shootRange,minShoot;

    void Start(){}

    void Update(){}

    void Die() { }

    public void Damages(int d)
    {
        this.hp -= d;
        if (this.hp < 0) { this.Die(); }
    }
}
