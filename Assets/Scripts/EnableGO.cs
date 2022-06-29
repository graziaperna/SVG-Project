using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGO : MonoBehaviour
{
    public GameObject Delimiters;
    public bool activable = false;
    public bool disactivable = false;

    
    void OnTriggerExit2D(Collider2D other)
        {
        if (activable)
        { 
            if (other.name == "aren")
            {
                Enable();
            }
        } else {
            if (other.name == "aren")
            {
                Disable();
            }
        }

    }

    void Enable()
    {
        Delimiters.SetActive(true);
    }

    void Disable()
    {
        Delimiters.SetActive(false);
    }


    
}
