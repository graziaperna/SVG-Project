using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    CambioScena scena;
    private Transform child;
    private UnityEngine.UI.Button buttonInventorySlot;
    public bool slot = false;
    private GameObject obj2;
    private bool musicPlaying = true;
    MusicManager musicMan;
    private GameObject music;

    public void Start()
    {

        if (slot) {

            buttonInventorySlot = GameObject.FindWithTag("slotFiaccola").GetComponent<UnityEngine.UI.Button>();
            buttonInventorySlot.onClick.AddListener(() => TaskOnClick());
        }
        
    }
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void Load()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void GoOn()
    {
        SceneManager.LoadScene(2);
    }

    public void TaskOnClick()
    {
        Debug.Log(buttonInventorySlot.name);
        if (buttonInventorySlot.name == "Slot_fiaccola(Clone)")
        {
            obj2 = GameObject.FindWithTag("fiaccola");
            Debug.Log("entrato");
        }

        obj2.GetComponent<SpriteRenderer>().enabled = true;
        obj2.GetComponent<BoxCollider2D>().enabled = true;
        Destroy(buttonInventorySlot.gameObject);
    }

    public void volume()
    {
        music = GameObject.FindWithTag("music");
        musicMan = music.GetComponent<MusicManager>();
        
        musicMan.stopOrPlay(musicPlaying);
        
        musicPlaying = !musicPlaying;
    }
}
