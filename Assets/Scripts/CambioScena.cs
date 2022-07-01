using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CambioScena : MonoBehaviour
{
    public int SceneNumber;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj1 = GameObject.FindWithTag("aren");

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            obj1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            obj1.GetComponent<Animator>().enabled = false;
        }
        else
        {
            obj1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            obj1.GetComponent<Animator>().enabled = true;
            obj1.transform.Translate(0f, -0.1f, 0f);
        }
        if (other.name == "aren" || other.name == "aren1")
        {
            SceneManager.LoadScene(SceneNumber, LoadSceneMode.Single);
        }
    }
}
