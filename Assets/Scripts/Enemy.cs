using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject target;

    public 

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
        
    }
    


    void ChasePlayer()
    {
        MoveTo();
    }
    
}
