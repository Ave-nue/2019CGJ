﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPants : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.PowerUP();
 
            Destroy(this.gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ;
    }

}
