using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
    public int hp , deg, def;
    public bool player=false;
    public float MvRange, shootRange,minShoot;
    Vector3 oldPos;
    void Start(){ oldPos = transform.position; }

    void Update()
    { if (Vector3.Distance(transform.position, oldPos) >= this.MvRange) { this.MvTo(transform.position); } }

    void Die() { Destroy(gameObject); }
    public void Damages(int d)
    {
        this.hp -= d;
        if (this.hp <= 0) { this.Die(); }
    }
    public void MvTo(Vector3 d)
    {
        oldPos = transform.position;
        GetComponent<UnityEngine.AI.NavMeshAgent>().destination = d;
    }
}
