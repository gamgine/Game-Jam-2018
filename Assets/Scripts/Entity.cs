using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity : MonoBehaviour
{
    public int hp , deg, def;
    public GameObject sprite;
    public bool player=false;
    public float MvRange, shootRange,minShoot;
    public List<Entity> triger = new List<Entity>();
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
    public void OnTriggerEnter(Collider other)
    { if (other.gameObject.GetComponent<Entity>()) { triger.Add(other.gameObject.GetComponent<Entity>()); } }
    public void OnTriggerExit(Collider other)
    { if (other.gameObject.GetComponent<Entity>()) { triger.Remove(other.gameObject.GetComponent<Entity>()); } }
}
