using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = .2f;

        if (gameObject.name == "Bump1")
        {
            transform.Translate(0, Input.GetAxis("Horizontal") * speed, 0);
        }
        else
            transform.Translate(0, Input.GetAxis("Vertical") * speed, 0);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 4), 0);
    }
}
