﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_Points;
    SpriteRenderer sprite;
    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_Radius = 0.01f;

    [SerializeField]
    private float m_TimeToNextPoint;

    private bool m_Waiting;

    private int m_Index;

    private int m_Direction = 1;

    public bool IsEmpty => m_Points.Length == 0;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (IsEmpty)
        {
            return;
        }

        if (!m_Waiting)
        {
            if (Vector3.Distance(m_Points[m_Index].position, transform.position) <= m_Radius)
            {
                m_Waiting = true;
                transform.position = m_Points[m_Index].transform.position;
                Invoke("NextWayPoint", m_TimeToNextPoint);
                flip();
            }

            transform.position = Vector3.MoveTowards(transform.position, m_Points[m_Index].position, Time.deltaTime * m_Speed);
        }
    }

    private void NextWayPoint()
    {
        m_Index += m_Direction;

        if (m_Index >= m_Points.Length || m_Index < 0)
        {
            m_Direction *= -1;
            m_Index += m_Direction * 2;
            
        }

        m_Waiting = false;
    }

    void flip(){
        
        if(sprite.flipX == true)
            sprite.flipX = false;
        else
            sprite.flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            player.spawn();
        }
    }
}
