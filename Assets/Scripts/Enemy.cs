using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    public float attack = 1f;
    public GameObject target;

    public float HateRange = 2f;
    public bool isHate = false;


    void Start()
    {
        base.Start();
        target = GameObject.Find("Player");
        if(target == null)
        {
            Debug.Log("can't find target Player");
        }
    }

    void Update()
    {
        SearchPlayer(HateRange);
        ChasePlayer();
    }
    


    void ChasePlayer()
    {
        if(isHate)
        MoveTo(target.transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, HateRange);
    }

    void SearchPlayer(float range)
    {
        float distance = (transform.position - target.transform.position).magnitude;
        Debug.Log(distance);
        if (distance > HateRange)
        {
            isHate = false;
        }
        else
            isHate = true;
    }

}
