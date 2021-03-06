using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private GameObject musicObj;
    MusicManager musicMan;
    private GameObject music;
    

    void Start()
    {
        
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("aren");
        GameObject[] objs1 = GameObject.FindGameObjectsWithTag("aren");

        music = GameObject.FindWithTag("music");

        musicMan = music.GetComponent<MusicManager>();

        if (objs.Length > 1 || objs1.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (musicMan.musicToChange)
        {
            if (musicMan.sceneChanged) { 
                if (SceneManager.GetActiveScene().name == "SampleScene")
                {
                    musicMan.changeMusic(0);
                }
                else if (SceneManager.GetActiveScene().name == "Tempio")
                {
                    musicMan.changeMusic(1);
                }
                else if (SceneManager.GetActiveScene().name == "Casa Baba")
                {
                    musicMan.changeMusic(2);
                }
            } else
            {
                if(musicMan.eventHappened == 1)
                {
                    musicMan.changeMusic(3);
                }
                if (musicMan.eventHappened == 2)
                {
                    musicMan.changeMusic(4);
                }
            }
        }
    }

    
}