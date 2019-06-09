using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidBrickSpawner : MonoBehaviour
{
    public int m_Height;
    public int m_Widht;
    public Transform m_BrickParent;
    [SerializeField] private GameObject m_BrickPrefab;
    private ArkanoidBrick m_Brick;

    private void Start()
    {
        for(int i = 0; i < m_Height; i++)
        {
            for(int j = 0; j < m_Widht; j++)
            {
                m_Brick = Instantiate(m_BrickPrefab, new Vector3(j*2 + m_BrickParent.position.x, i + m_BrickParent.position.y, 0), Quaternion.identity, m_BrickParent).GetComponent<ArkanoidBrick>();
                m_Brick.m_MaxLife = m_Height - 1;
                m_Brick.Index = i;
            }
        }
    }
}
