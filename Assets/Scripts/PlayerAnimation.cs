using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    public Player player;

    public float horizontal_speed = 0f;
    public float vertical_speed = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        horizontal_speed = player.movedir.x;
        vertical_speed = player.movedir.y;

        anim.SetFloat("horizontal_speed", horizontal_speed);    
        anim.SetFloat("vertical_speed", vertical_speed);
    }
}
