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
        if(player.isPowerUP)
            EscapePlayer();
        else
            ChasePlayer();
    }
    


    void ChasePlayer()
    {
        if (isHate)
            MoveTo(target.transform.position);
        else
            Move(new Vector2(0, 0));
    }

    void EscapePlayer()
    {
        Move((transform.position - target.transform.position) * escape_speed);
    }

    void StopChase()
    {
        if(isHate)
        {
            if((transform.position-target.transform.position).magnitude>LoveRange)
            {
                isHate = false;
                Move(new Vector2(0, 0));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(player.isPowerUP)
            {
                Destroy(gameObject,2);
            }
            else
            {
                player.Damage(attack);
            }
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
        else;
    }

}
