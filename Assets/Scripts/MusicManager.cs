using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] clip;
    public bool musicToChange = false;
    private int storyPoint;
    private GameObject musicGameObj;
    private string nameScene = "Intro";

    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != nameScene)
        {
            musicToChange = true;
            nameScene = SceneManager.GetActiveScene().name;
        }
    }

    public void changeMusic(int value)
    {
       GetComponent<AudioSource>().clip = clip[value];
       GetComponent<AudioSource>().Play();
        musicToChange = false;
    }
    
   
}
