using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject[] lifeSprites;
    public GameObject[] keysSprites;
    //0 - menu 1 - win 
    public GameObject[] PanelsMenu;


    [Header("Contadores")]
    public int TotalLife;
    public int TotalKeys;
    public int AllKeys;

    public bool KeyComplete;

    public Bau bau;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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
        if(Input.GetKeyDown(KeyCode.Escape)){
            
            if(Time.timeScale != 0){
                Time.timeScale = 0;
                PanelsMenu[0].SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                PanelsMenu[0].SetActive(false);
            }
        }
    }


    public void takeDamage(){
        TotalLife -= 1;
        lifeSprites[TotalLife].SetActive(false);
        if(TotalLife < 1){
            Destroy(this.gameObject);
            irMenu();
            Time.timeScale = 0;
        }
    }


    public void addKey(){
        TotalKeys++;
        keysSprites[TotalKeys - 1].SetActive(true);
    }

    public void voltarAoJogo(){
        PanelsMenu[0].SetActive(false);
        Time.timeScale = 1;
    }

    public void irMenu(){
        SceneManager.LoadScene("menuGeneric");
    }

    public void nextLevel(string level){
        SceneManager.LoadScene(level);
    }
}
