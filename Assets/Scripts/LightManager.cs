using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightManager : MonoBehaviour
{
    private GameObject Light;
    public bool LightMode = false;
    MusicManager musicMan;
    private GameObject music;
    public float tempo = 0;
    private bool wolfEnabled = false;
   
    // Update is called once per frame

    void Start()
    {
        Light = GameObject.FindWithTag("Light");
        music = GameObject.FindWithTag("music");

        musicMan = music.GetComponent<MusicManager>();
    }

    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo >= 2f && wolfEnabled)
        {
            SceneManager.LoadScene(7);
            musicMan.sceneChanged = false;
            musicMan.eventHappened = 2;
        }
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

        GameObject obj1 = GameObject.FindWithTag("aren");
        obj1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        obj1.GetComponent<Animator>().enabled = false;

        if (this.name == "attivatoreLuci(sfidaLupi)")
        {
            musicMan.sceneChanged = false;
            musicMan.eventHappened = 1;

            GameObject[] wolfObjects = GameObject.FindGameObjectsWithTag("wolf");

            for (int i = 0; i < wolfObjects.Length; i++)
            {
                wolfObjects[i].GetComponent<SpriteRenderer>().enabled = true;
                wolfEnabled = true;
                tempo = 0;
            }
        }
    }

    void ToLight()
    {
        Light.GetComponent<Light>().intensity = 1.5f;
    }
}
