using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    public float attack = 1f;
    public GameObject target;

    public float escape_speed =1f;

    public float HateRange = 2f;
    public float LoveRange = 3f;
    public bool isHate = false;

    [Tooltip("被揍飞的速度")]
    public float fly_speed = 10;

    public bool isfly = false;


    Player player;

    public void Start()
    {
        base.Start();
        target = GameObject.Find("Player");
        if(target == null)
        {
            Debug.Log("can't find target Player");
        }
        player = target.GetComponent<Player>();

    }

    public void Update()
    {
        SearchPlayer(HateRange);
        if(player.isPowerUP || player.isTempPower)
            EscapePlayer();
        else
            ChasePlayer();
    }
    


    void ChasePlayer()
    {
        if(!isfly)
        {
            if (isHate)
                MoveTo(target.transform.position);
            else
                Move(new Vector2(0, 0));
        }
    }

    void EscapePlayer()
    {
        if(!isfly)
        Move((transform.position - target.transform.position) * escape_speed);
    }

    //void StopChase()
    //{
    //    if(isHate)
    //    {
    //        if((transform.position-target.transform.position).magnitude>LoveRange)
    //        {
    //            isHate = false;
    //            Move(new Vector2(0, 0));
    //        }
    //    }
    //}

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(player.isPowerUP)
            {
                // 揍飞
                isfly = true;
                GetComponent<CircleCollider2D>().enabled = false;
                Vector2 dir = player.rg.velocity;
                Move(dir * fly_speed);

                LevelPanel.levelPanel.BottomFrame();
                LevelPanel.levelPanel.ShakeObj(transform);


                //得分
                Point.AddPoint(100 * player.kill_number);
                player.kill_number++;

            }
            else
            {
                player.Damage(attack);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Damage(attack);

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, HateRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LoveRange);
    }

    void SearchPlayer(float range)
    {
        float distance = (transform.position - target.transform.position).magnitude;

        if (distance > LoveRange)
        {
            isHate = false;
        }
        else if (distance < HateRange)
            isHate = true;
    }

}
