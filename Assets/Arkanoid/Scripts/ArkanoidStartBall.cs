using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidStartBall : MonoBehaviour
{
    public float m_Speed = 1000f;
    [SerializeField]
    private KeyCode m_LauchKey = KeyCode.Space;
    [SerializeField]
    private GameObject m_Paddle;
    [SerializeField]
    private GameObject m_BallPrefab;
    private GameObject m_Ball;
    private bool m_Launched = false;

    private void Start()
    {
        SpawnBall();
    }

    private void LaunchBall()
    {
        float y = 1;
        float x = Random.Range(-1.0f, 1.0f);
        Vector3 force = new Vector3(x, y, 0) * m_Speed;
        m_Ball.GetComponent<Rigidbody>().AddForce(force);
    }

    private void Update()
    {
        if (!m_Launched)
        {
            FollowPaddle();
        }
        if (Input.GetKeyDown(m_LauchKey) && !m_Launched)
        {
            LaunchBall();
            m_Launched = true;
        }
        if (m_Ball == null)
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        m_Ball = Instantiate(m_BallPrefab, this.transform.position, Quaternion.identity, this.transform);
        m_Launched = false;
    }

    private void FollowPaddle()
    {
        Vector3 position = m_Ball.transform.position;
        position.x = m_Paddle.transform.position.x;
        transform.position = position;
    }
}
