using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    Rigidbody2D rg;

    public bool isTransportCD = false;
    public GameObject TransportJustLeave;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        MoveUpdate();
    }


    // 控制移动
    void MoveUpdate()
    {
        Vector2 movedir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Debug.Log("movedir:" + movedir);
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


}
