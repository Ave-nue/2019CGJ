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
        if (collision.gameObject.tag == "Player") Debug.Log("trans");
        Player player = collision.gameObject.GetComponent<Player>();
        player.isTransportCD = true;
        player.Transport(target.transform.position);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        player.isTransportCD = false;
        
    }
}
