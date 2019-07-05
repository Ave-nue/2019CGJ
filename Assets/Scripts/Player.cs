using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    
    Rigidbody2D rg;

    public float MAX_HP = 10f;
    public float HP = 10f;
    public Slider HPBar;
    [System.NonSerializedAttribute]
    public bool isTransportCD = false;
    public GameObject TransportJustLeave;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        MoveUpdate();
        updateHpBar();
    }


    // 控制移动
    void MoveUpdate()
    {
        Vector2 movedir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Debug.Log("movedir:" + movedir);
        if (movedir != new Vector2(0, 0))
        {
            //rg.velocity = movedir * speed;
            Move(movedir);
        }
    }

    // 传送到坐标
    public void Transport(Vector3 pos)
    {
        transform.position = pos;
        isTransportCD = true;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "Enemy") 
        {
            Debug.Log("hitenemy");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Damage(enemy.attack);
        }
    }

    // 受伤害
    public void Damage(float damage)
    {
        Debug.Log("damage");
        if(HP-damage>=0)
            HP -= damage;
        else
        {
            HP = 0;
        }
    }

    void updateHpBar()
    {
        HPBar.value = HP / MAX_HP;
    }



    


}
