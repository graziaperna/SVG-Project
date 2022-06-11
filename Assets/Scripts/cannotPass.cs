using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider2D))]

public class cannotPass : MonoBehaviour
{
    public GameObject Text;
    public GameObject Panel;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "aren")
        {
            showMessage();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.name == "aren")
        {
           hideMessage();
        }
    }

    protected void showMessage()
    {
        Panel.SetActive(true);
        Text.SetActive(true);
    }

    protected void hideMessage()
    {
        Panel.SetActive(false);
        Text.SetActive(false);
    }


}