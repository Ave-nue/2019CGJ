using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportPoint : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.isTransportCD == false)
            {
                player.isTransportCD = true;
                player.Transport(target.transform.position);
                player.TransportJustLeave = this.gameObject;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(player.TransportJustLeave!=gameObject)
            player.isTransportCD = false;
    
        }
        
    }
}
