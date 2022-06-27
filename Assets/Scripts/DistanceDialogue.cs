using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDialogue : MonoBehaviour
{
    public UnityEngine.UI.Button continueDialogueButton;
    public GameObject dialogueBox;
    public GameObject conversation;
    public Rigidbody2D aren;
    private Transform child;
    private int dialogue = 0;

    // Start is called before the first frame update
    void Start()
    {

        if (dialogue < conversation.transform.childCount)
        {
            child = conversation.transform.GetChild(dialogue);
        }
        continueDialogueButton.onClick.AddListener(TaskOnClick);
        dialogueBox.SetActive(true);
        conversation.SetActive(true);
            
        Conversation();

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
            aren.bodyType = RigidbodyType2D.Dynamic;
            aren.GetComponent<Animator>().enabled = true;
            continueDialogueButton.GetComponent<CanvasGroup>().alpha = 0f;
            continueDialogueButton.GetComponent<CanvasGroup>().interactable = false;
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
