using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public void StartGame(){
         SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
