using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class Bau : MonoBehaviour
{
    public bool FaseComplete;
    public LevelManager l;
    public Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(FaseComplete){
                Debug.Log("Você Conseguiu!");
                Time.timeScale = 0;
                anim.Play("BauAnimation");
            }
        }
    }

    public void telaWin(){
        Time.timeScale = 0;
        l.PanelsMenu[1].SetActive(true);
    }
}
