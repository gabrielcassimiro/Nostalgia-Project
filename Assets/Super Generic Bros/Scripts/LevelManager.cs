using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject[] lifeSprites;
    public GameObject[] keysSprites;


    [Header("Contadores")]
    public int TotalLife;
    public int TotalKeys;
    public int AllKeys;

    public bool KeyComplete;

    public Bau bau;

    // Start is called before the first frame update
    void Start()
    {
        TotalLife = 3;
        TotalKeys = 0;
        foreach(GameObject life in lifeSprites){
                life.SetActive(true);
            }
        foreach(GameObject key in keysSprites){
            key.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!KeyComplete && TotalKeys >= AllKeys){
            KeyComplete = true;
            bau.FaseComplete = KeyComplete;
        }
    }


    public void takeDamage(){
        TotalLife -= 1;
        lifeSprites[TotalLife].SetActive(false);
        if(TotalLife < 1){
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
    }


    public void addKey(){
        TotalKeys++;
        keysSprites[TotalKeys - 1].SetActive(true);
    }
}
