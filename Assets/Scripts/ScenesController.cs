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
}
