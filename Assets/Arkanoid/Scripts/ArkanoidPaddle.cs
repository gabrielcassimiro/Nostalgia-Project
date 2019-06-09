using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidPaddle : MonoBehaviour
{
    public float m_Speed = 10.0f;
    public bool m_IsBoosting = false;

    private void Update()
    {
        float x = Input.GetAxisRaw("HorizontalAD") * m_Speed * Time.deltaTime;
        transform.Translate(x, 0, 0);
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -21, 21);
        transform.position = position;

        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && !m_IsBoosting)
        {
            m_Speed *= 1.5f;
            m_IsBoosting = true;
        }
        if ((Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) && m_IsBoosting)
        {
            m_Speed /= 1.5f;
            m_IsBoosting = false;
        }
    }
}
