using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CambioScena : MonoBehaviour
{
    public int SceneNumber;

    void OnTriggerEnter2D(Collider2D other)
    {
         
        if(other.name == "aren")
        {  
           SceneManager.LoadScene(SceneNumber, LoadSceneMode.Single);  
        }
    } 
}
