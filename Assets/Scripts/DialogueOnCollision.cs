using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueOnCollision : MonoBehaviour
{
    public UnityEngine.UI.Button continueDialogueButton;
    public GameObject dialogueBox;
    public GameObject conversation;
    private Transform child;
    private int dialogue = 0;
    private Rigidbody2D player;
    private GameObject esben;
    private GameObject fiaccola;
    private SpriteRenderer spriteEsben;
    private Collider2D colliderEsben;
    private Collider2D colliderFiaccola;
    public bool interacted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
         
        if(other.name == "aren" && !interacted)
        {
           player = other.attachedRigidbody;
           player.bodyType = RigidbodyType2D.Static;
           player.GetComponent<Animator>().enabled = false;
           
            if (dialogue < conversation.transform.childCount)
            {
                child = conversation.transform.GetChild(dialogue);
            }
            continueDialogueButton.onClick.AddListener(TaskOnClick);
            dialogueBox.SetActive(true);
            conversation.SetActive(true);
            
            Conversation();
            interacted = true;

        }

        if(this.name == "esben2") {
            GameObject.Find("colliderToEnter(Taverna)").GetComponent<BoxCollider2D>().enabled = true;
            if(GameObject.Find("fiaccola") != null) { 
                GameObject.Find("fiaccola").GetComponent<BoxCollider2D>().enabled = true;
            }
            
        }
        if(this.name == "altare") {     
            GameObject.Find("collideruscita").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("colliderToEnter(Tempio)").GetComponent<BoxCollider2D>().enabled = false;

        }
    } 


    void TaskOnClick()
    {

        dialogue++;

        child.GetComponent<CanvasGroup>().alpha = 0f;
        child.GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (dialogue == conversation.transform.childCount)
        {
            dialogueBox.SetActive(false);
            conversation.SetActive(false);
            player.bodyType = RigidbodyType2D.Dynamic;
            player.GetComponent<Animator>().enabled = true;
            continueDialogueButton.GetComponent<CanvasGroup>().alpha = 0f;
            continueDialogueButton.GetComponent<CanvasGroup>().interactable = false;
            if(SceneManager.GetActiveScene().name == "Tempio") {

                esben = GameObject.Find("esben2");
                spriteEsben = esben.GetComponent<SpriteRenderer>();
                spriteEsben.enabled = true;

                colliderEsben = esben.GetComponent<BoxCollider2D>();
                colliderEsben.enabled = true; 
               
            }
            
        }
    }

    void Conversation()
    {
         if(dialogue == 0){
            child.GetComponent<CanvasGroup>().alpha = 1f;
            child.GetComponent<CanvasGroup>().blocksRaycasts = true;
            continueDialogueButton.GetComponent<CanvasGroup>().alpha = 1f;
            continueDialogueButton.GetComponent<CanvasGroup>().interactable = true;
        } else if(dialogue == 1)
        {
            child.GetComponent<CanvasGroup>().alpha = 1f;
            child.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }




  
}
