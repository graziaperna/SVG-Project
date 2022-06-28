using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private GameObject Light;
    public bool LightMode = false;
    // Update is called once per frame

    void Start()
    {
        Light = GameObject.FindWithTag("Light");
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
    }

    void ToLight()
    {
        Light.GetComponent<Light>().intensity = 1.5f;
    }
}
