using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuGameGeneric : MonoBehaviour
{

    private void Start() {
        Time.timeScale = 1;
    }
    public void irMenu(){
        SceneManager.LoadScene("menu");
    }

    public void jogar(){
        SceneManager.LoadScene("fase_1");
    }
}
