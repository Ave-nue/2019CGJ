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
        if(collision.gameObject.tag == "Player")
            pants.SetActive(false);
    }
}
