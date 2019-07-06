using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPower : MonoBehaviour
{
    public float powertime = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("fuck");
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.GetTempPower(powertime);

            Destroy(this.gameObject);
        }

    }
}
