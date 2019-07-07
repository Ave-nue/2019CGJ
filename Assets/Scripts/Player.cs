using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    
    //Rigidbody2D rg;

    public float MAX_HP = 10f;
    public float HP = 10f;
    [System.NonSerializedAttribute]
    public bool isTransportCD = false;
    public GameObject TransportJustLeave;

    public bool isPowerUP = false;
    public bool isTempPower = false;

    public int point = 0;
    public int kill_number = 1;

    public Vector2 movedir;
    public bool is_effecting = false;

    public GameObject pant;

    private float m_winTime;
    private Animator m_animator;

    new void Start()
    {
        base.Start();

        m_animator = GetComponent<Animator>();
        LevelPanel.levelPanel.ResetPoint();
        updateHpBar();
        //rg = GetComponent<Rigidbody2D>();    
    }

    new void Update()
    {
        base.Update();
        MoveUpdate();
        updateHpBar();

        if (m_winTime != 0 && Time.time > m_winTime)
        {
            LevelPanel.levelPanel.GameWin();
            m_winTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            m_animator.SetTrigger("piaorou");
            SoundMgr.Instance().PlaySoundEffect(1);
        }
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
            if(HP-damage>=0)
                HP -= damage;
            else
            {
                HP = 0;
                LevelPanel.levelPanel.GameOver();
            }

            //特效
            is_effecting = true;
            
        }
    }

    // 变身无敌
    public void PowerUP()
    {
        isPowerUP = true;
        LevelPanel.levelPanel.WarePant();
        m_winTime = Time.time + 5;
        SoundMgr.Instance().PlaySoundEffect(1);
        pant.SetActive(true);
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
        LevelPanel.levelPanel.SetHP(HP / MAX_HP);
    }

 





    



    


}
