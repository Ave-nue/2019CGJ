using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    public Player player;

    public GameObject effect;
    public Animator effect_anim;

    public float horizontal_speed = 0f;
    public float vertical_speed = 0f;


    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        effect = transform.GetChild(0).gameObject;
        effect_anim = effect.GetComponent<Animator>();
    }

    void Update()
    {
        if (player.is_effecting)
            effect.SetActive(true);
        else
            effect.SetActive(false);
        horizontal_speed = player.movedir.x;
        vertical_speed = player.movedir.y;

        anim.SetFloat("horizontal_speed", horizontal_speed);
        anim.SetFloat("vertical_speed", vertical_speed);

        AnimatorStateInfo stateinfo = effect_anim.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.normalizedTime > 1.0f)
        {
            player.is_effecting = false;
        }

    }
}
