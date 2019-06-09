using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOver"))
        {
            GameObject.Find("GameManager").GetComponent<ArkanoidGameManager>().m_Vidas--;
            Destroy(this.gameObject);
        }
    }
}
