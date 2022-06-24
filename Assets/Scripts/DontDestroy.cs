using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public AudioClip[] clip;
    private int nclip = 0;
    private GameObject music;
    CambioScena scena;
    public GameObject objectEvent;


    void Start()
    {
        
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("aren");
        music = GameObject.FindWithTag("music");
        scena = objectEvent.GetComponent<CambioScena>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene" && scena.changed == true)
        {
        nclip = 0;
        changeMusic();
        }
        else if (SceneManager.GetActiveScene().name == "Tempio" && scena.changed == true)
        {
            nclip = 1;
            changeMusic();
        }
        else if (SceneManager.GetActiveScene().name == "Casa Baba" && scena.changed == true)
        {
            nclip = 2;
            changeMusic();
        }
    }

    void changeMusic()
    {
            music.GetComponent<AudioSource>().clip = clip[nclip];
            music.GetComponent<AudioSource>().GetComponent<AudioSource>().Play();
            scena.setChanged(false);
    }
}