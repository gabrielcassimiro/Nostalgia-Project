using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public string MenuName;

    public void goToMenu(){
        SceneManager.LoadScene("menu");
    }

    public void GenericBros()
    {
        SceneManager.LoadScene("menuGeneric");
    }
    public void Pong()
    {
        SceneManager.LoadScene("Pong Game");
    }
    public void Arkanoid()
    {
        SceneManager.LoadScene("Arkanoid");
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
