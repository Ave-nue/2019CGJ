using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Wall : MonoBehaviour
{
    bool isfly = false;
    public float fly_speed = 3f;

    Rigidbody2D rg;


    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
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
            if (player.isPowerUP)
            {
                // 揍飞
                isfly = true;
                GetComponent<CircleCollider2D>().enabled = false;
                Vector2 dir = player.rg.velocity;
                rg.constraints = RigidbodyConstraints2D.None;
                rg.velocity = dir * fly_speed;

                //顿帧
                LevelPanel.levelPanel.BottomFrame();
                LevelPanel.levelPanel.ShakeObj(transform);


            }
        }
    }
}
