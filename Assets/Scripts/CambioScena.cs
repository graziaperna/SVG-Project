using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CambioScena : MonoBehaviour
{
    public int SceneNumber;
    public bool changed = true;
    void OnTriggerEnter2D(Collider2D other)
    {
         
        if(other.name == "aren")
        {  
           SceneManager.LoadScene(SceneNumber, LoadSceneMode.Single);
            setChanged(true);
        }
    }

    public void setChanged(bool value)
    {
        changed = value;
    }
}
