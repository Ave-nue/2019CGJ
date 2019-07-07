using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Wall : MonoBehaviour
{
    bool isfly = false;
    public float fly_speed = 3f;
    public float rotate_speed = 100f;

    Rigidbody2D rg;


    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("fuck");
        transform.Rotate(transform.rotation.eulerAngles+new Vector3(0, 0, rotate_speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.isPowerUP)
            {
                SoundMgr.Instance().PlaySoundEffect(2);
                // 揍飞
                isfly = true;
                GetComponent<CircleCollider2D>().enabled = false;
                Vector2 dir = player.rg.velocity;
                if (dir.magnitude < 1)
                    dir *= 1/ dir.magnitude;
                rg.constraints = RigidbodyConstraints2D.None;
                rg.velocity = dir * fly_speed;

                rotate_speed = 100f;

                //顿帧
                LevelPanel.levelPanel.BottomFrame();
                LevelPanel.levelPanel.ShakeObj(transform);


            }
        }
    }
}
