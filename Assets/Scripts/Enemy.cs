using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    public float attack = 1f;
    public GameObject target;

    public float HateRange = 2f;
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
        Move((transform.position - target.transform.position)*0.02f);
    }

    void StopChase()
    {
        if(isHate)
        {
            if((transform.position-target.transform.position).magnitude>HateRange)
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
        Gizmos.DrawWireSphere(this.transform.position, HateRange);
    }

    void SearchPlayer(float range)
    {
        float distance = (transform.position - target.transform.position).magnitude;

        if (distance > HateRange)
        {
            isHate = false;
        }
        else
            isHate = true;
    }

}
