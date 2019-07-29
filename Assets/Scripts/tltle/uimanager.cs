using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uimanager : MonoBehaviour
{
    public static int pllifenum;
    public Image[] pllife;
    public static int plboomnum;
    public Image[] plboom;
    public static int score;
    public Text scoretext;
    public AudioSource pauseaud;
    public AudioSource bgmaud;
    public AudioSource gameoveraud;
    public static bool entergameover = false;
    public GameObject pauseUI;

    void Start()
    {
        score = 0;
        pllifenum = 7;
        plboomnum = 3;
    }
    void Update()
    {
        scoretext.text = score.ToString();
        for (int i = 0; i < 7; i++)
            pllife[i].enabled = false;
        for (int i = 0; i < 7; i++)
            plboom[i].enabled = false;
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseorunpause();
        for(int i=0;i<pllifenum;i++)
            pllife[i].enabled = true;
        for (int i = 0; i < plboomnum; i++)
            plboom[i].enabled = true;

        if(entergameover)
        {
            Time.timeScale = 0;
            bgmaud.Stop();
            gameoveraud.Play();
            pauseUI.SetActive(true);
            pauseUI.transform.GetChild(2).gameObject.SetActive(false);
            entergameover = false;
        }
    }

    public void pauseorunpause()
    {
        pauseaud.Play();
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            bgmaud.Pause();
            pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            bgmaud.UnPause();
            pauseUI.SetActive(false);
        }
    }

    public void endgame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("title");
    }

    public void restartgame()
    {
        motion.playerstate = motion.PlayerState.general;
        Time.timeScale = 1;
        SceneManager.LoadScene("level1");
    }
}
