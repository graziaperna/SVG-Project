using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    CambioScena scena;
    public GameObject objectEvent;
    private Transform child;
    private UnityEngine.UI.Button buttonInventorySlot;
    public bool slot = false;
    private GameObject obj2;
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

    }
    public void GoOn()
    {
        scena = objectEvent.GetComponent<CambioScena>();
        scena.setChanged(true);
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
        Destroy(buttonInventorySlot.gameObject);
    }
}
