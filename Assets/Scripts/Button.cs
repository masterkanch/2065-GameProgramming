using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    public void StartGame(){
        _audioSource.DOFade(0.0f,1.0f);
        Invoke("LoadScene",1f);
    }

    private void LoadScene(){
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
