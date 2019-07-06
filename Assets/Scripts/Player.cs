using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    
    //Rigidbody2D rg;

    public float MAX_HP = 10f;
    public float HP = 10f;
    public Slider HPBar;
    [System.NonSerializedAttribute]
    public bool isTransportCD = false;
    public GameObject TransportJustLeave;

    public bool isPowerUP = false;
    public bool isTempPower = false;

    public int point = 0;
    public int kill_number = 1;

    public Vector2 movedir;

    new void Start()
    {
        base.Start();
        //rg = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        MoveUpdate();
        updateHpBar();
    }


    // 控制移动
    void MoveUpdate()
    {
        movedir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

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

    
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("hit");
    //    if (collision.gameObject.tag == "Enemy") 
    //    {
    //        Debug.Log("hitenemy");
    //        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    //        Damage(enemy.attack);
    //    }
    //}

    // 受伤害
    public void Damage(float damage)
    {
        if(isTempPower==false)
        {
            Debug.Log("damage");
            if(HP-damage>=0)
                HP -= damage;
            else
            {
                HP = 0;
                LevelPanel.levelPanel.GameOver();
            }

        }
    }

    // 变身无敌
    public void PowerUP()
    {
        isPowerUP = true;
        //GetComponent<SpriteRenderer>().color = Color.red;
    }

    // 暂时无敌，不能揍飞

    public void GetTempPower(float time)
    {
        Debug.Log("kaishi");
        StartCoroutine("TempPower", time);
    }
    public IEnumerator TempPower(float time)
    {
        Debug.Log("temp power");
        isTempPower = true;
        GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSecondsRealtime(time);
        isTempPower = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void updateHpBar()
    {
        if (HPBar!= null)
        HPBar.value = HP / MAX_HP;
    }

 





    



    


}
