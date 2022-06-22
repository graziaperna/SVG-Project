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
    private SpriteRenderer sprite;
    private Collider2D collider;
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
                sprite = esben.GetComponent<SpriteRenderer>();
                sprite.enabled = true;

                collider = esben.GetComponent<Collider2D>();
                collider.enabled = true;
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
