using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBooy : MonoBehaviour
{
    GameObject pants;
    void Start()
    {
        pants = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.PowerUP();
            pants.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.PowerUP();

            pants.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
