using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    CambioScena scena;
    public GameObject objectEvent;

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

    }
    public void GoOn()
    {
        scena = objectEvent.GetComponent<CambioScena>();
        scena.setChanged(true);
        SceneManager.LoadScene(2);
    }
}
