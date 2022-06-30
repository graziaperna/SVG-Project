using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private GameObject Light;
    public bool LightMode = false;
    MusicManager musicMan;
    private GameObject music;
    // Update is called once per frame

    void Start()
    {
        Light = GameObject.FindWithTag("Light");
        music = GameObject.FindWithTag("music");

        musicMan = music.GetComponent<MusicManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (LightMode)
        {
            if (other.name == "aren")
            {
                ToLight();
            }
        }
        else
        {
            if (other.name == "aren")
            {
                toObscure();
            }
        }

    }

    void toObscure()
    {
        Light.GetComponent<Light>().intensity =  0.3f;
        if(this.name == "attivatoreLuci(sfidaLupi)")
        {
            musicMan.sceneChanged = false;
            musicMan.eventHappened = 1;
        }
    }

    void ToLight()
    {
        Light.GetComponent<Light>().intensity = 1.5f;
    }
}
