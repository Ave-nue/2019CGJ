﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rg;

    public float horizontal_speed = 0f;
    public float vertical_speed = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal_speed = rg.velocity.x;
        vertical_speed = rg.velocity.y;

        anim.SetFloat("horizontal_speed", horizontal_speed);
        anim.SetFloat("vertical_speed", vertical_speed);
    }
}