using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidBrick : MonoBehaviour
{
    public int m_Life = 1;
    public float m_MaxLife = 5;
    public int Index { get; set; }

    public Color m_StartColor;
    public Color m_EndColor;

    private Renderer m_Renderer;

    private void Start()
    {
        m_Life = Index;
        //m_Life = Random.Range(0, (int)m_MaxLife);
        m_Renderer = GetComponent<Renderer>();
        Color color = Color.Lerp(m_StartColor, m_EndColor, m_Life / m_MaxLife);
        m_Renderer.material.SetColor("_Color", color);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (--m_Life <= 0)
        {
            GameObject.Find("GameManager").GetComponent<ArkanoidGameManager>().m_Pontos++;
            Destroy(gameObject);
        }

        Color color = Color.Lerp(m_StartColor, m_EndColor, m_Life / m_MaxLife);
        m_Renderer.material.SetColor("_Color", color);
    }
}
