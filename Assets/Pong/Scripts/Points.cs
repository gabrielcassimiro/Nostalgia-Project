 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text points1Text, points2Text;

    private static int points1, points2;

    public GameObject ballPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Ball>())
        {
            if(gameObject.name == "punctuator1")
            {
                points1++;
                points1Text.text = points1.ToString();
            }
            else
            {
                points2++;
                points2Text.text = points2.ToString();
            }
            Destroy(other.gameObject);
            Instantiate(ballPrefab, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
