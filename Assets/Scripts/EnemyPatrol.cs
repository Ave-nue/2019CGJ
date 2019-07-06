using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{

    public GameObject[] points;
    public float StayTime = 2f;

    public GameObject current_target;


    int count;
    int index;
    int step = 1;

    bool isWalk = true;



    new void Start()
    {
        base.Start();
        count = points.Length;
        current_target = points[0];
        index = 0;
    }

    // Update is called once per frame
    new void Update()
    {
        MoveTo(current_target.transform.position);
        if ((transform.position - current_target.transform.position).magnitude < 0.1f && isHate==false)
        {
            index += step;
            if (index == 0 || index == count - 1)
                step = -step;
            Debug.Log(index);
            current_target = points[index];

        }

        SearchPlayer(HateRange);
        ChasePlayer();

    }
    void ChasePlayer()
    {
        if (isHate)
            MoveTo(target.transform.position);
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
    }


}


