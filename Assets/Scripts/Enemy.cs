﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{

    public GameObject target;


    void Start()
    {
        target = GameObject.Find("Player");
        if(target == null)
        {
            Debug.Log("can't find target Player");
        }
    }

    void Update()
    {
        ChasePlayer();
    }
    


    void ChasePlayer()
    {
        MoveTo(target.transform.position);
    }
    
}
