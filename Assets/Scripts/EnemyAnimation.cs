using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rg;

    public GameObject effect;
    public Animator effect_anim;

    public float horizontal_speed = 0f;
    public float vertical_speed = 0f;

    public Enemy enemy;

    void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();

        effect = transform.GetChild(0).gameObject;
        effect_anim = effect.GetComponent<Animator>();

        enemy = gameObject.GetComponent<Enemy>();
    }

    void Update()
    {

        horizontal_speed = rg.velocity.x;
        vertical_speed = rg.velocity.y;

        anim.SetFloat("horizontal_speed", horizontal_speed);
        anim.SetFloat("vertical_speed", vertical_speed);

        //AnimatorStateInfo stateinfo = effect_anim.GetCurrentAnimatorStateInfo(0);
        //if (stateinfo.normalizedTime > 1.0f)
        //{
        //    enemy.is_effecting = false;
        //}
    }
}
