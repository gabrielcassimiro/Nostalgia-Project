using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArkanoidGameManager : MonoBehaviour
{
    [Header("Variaveis")]
    public int m_Pontos = 0;
    public int m_Vidas = 3;
    [SerializeField]
    private string m_LevelName;

    [Header("Textos")]
    public Text m_PontosText;
    public Text m_VidasText;


    private void Update()
    {
        m_PontosText.text = "Pontos: " + m_Pontos.ToString("00");
        m_VidasText.text = "Vidas: " + m_Vidas.ToString("0");

        if(m_Vidas <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(m_LevelName);
    }
}
