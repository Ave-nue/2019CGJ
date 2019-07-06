using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomPoint : MonoBehaviour
{
    public GameObject enemyPfb;
    public float generateCD;
    public int totalCount;
    public float genRect;

    private float lastGeneTick;
    private int hasGene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGene < totalCount
            && (lastGeneTick <= 0 || lastGeneTick + generateCD <= Time.time))
            GenerateEnemy();
    }

    void GenerateEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPfb);
        newEnemy.transform.SetPositionAndRotation(transform.position + UnityEngine.Random.insideUnitSphere * genRect, Quaternion.identity);
        lastGeneTick = Time.time;
        hasGene++;
    }
}
