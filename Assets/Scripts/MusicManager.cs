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
    public bool sceneChanged = true;
    public int eventHappened = 0;
    private int lastEventHappened = 0;
    

    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (sceneChanged)
        {
            if (SceneManager.GetActiveScene().name != nameScene)
            {
                musicToChange = true;
                nameScene = SceneManager.GetActiveScene().name;
            }
        } else
        {
            if (eventHappened != lastEventHappened)
            {
                musicToChange = true;
                lastEventHappened = eventHappened;
            }
        }
    }

    public void changeMusic(int value)
    {
       GetComponent<AudioSource>().clip = clip[value];
       GetComponent<AudioSource>().Play();
        musicToChange = false;
    }
    
    public void stopOrPlay(bool music)
    {
        GetComponent<AudioSource>().mute = music;
    }
   
}
