using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class title : MonoBehaviour
{
    public GameObject idle;
    public GameObject loading;
    AudioSource aud;

    void Start()
    {
        aud = GetComponent<AudioSource>();
    }


    public void quitgame()
    {
        aud.Play();
        Application.Quit();
    }

    public void startgame()
    {
        aud.Play();
        SceneManager.LoadSceneAsync("level1");
        idle.SetActive(false);
        loading.SetActive(true);
    }
}