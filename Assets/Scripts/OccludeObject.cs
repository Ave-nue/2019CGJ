﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccludeObject : MonoBehaviour
{
    Collider2D m_collider2D;
    // Start is called before the first frame update
    public void Start()
    {
        m_collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (m_collider2D != null)
            RefreshZ();
    }

    void RefreshZ()
    {
        Vector3 colliderPos = m_collider2D.bounds.center;
        float offSet = transform.position.y - colliderPos.y;
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, GetZByY(colliderPos.y) + offSet);
        transform.SetPositionAndRotation(newPos, Quaternion.identity);
    }

    float GetZByY(float y)
    {
        return -y;
    }
}
