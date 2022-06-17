using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTo : MonoBehaviour
{
    private Vector3 destinationPosition;
    private Vector3 movement;
    public GameObject destination;
    private Rigidbody player;
    public bool move = false;
    public Animator animator;
    float speed = 1f;
    public GameObject dialogueBox;
    public GameObject conversation;
    private int dialogue = 0;
    private Transform child;
    public UnityEngine.UI.Button continueDialogueButton;

    // Start is called before the first frame update
    void Start()
    {
        destination.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        destination.GetComponent<Animator>().enabled = false;

        destinationPosition = destination.transform.position;
        destinationPosition.x = destinationPosition.x + 0.2f;
        movement = new Vector3(-1,0,0);
        move = true;
        continueDialogueButton.onClick.AddListener(TaskOnClick);

    }

    void Update() {
        
        if(move) {
        Move();

        }
        
    }


    void Move() {

     transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed* Time.deltaTime);
     animator.SetFloat("Horizontal", movement.x);
     animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed",  transform.position.sqrMagnitude);
        
        destination.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        destination.GetComponent<Animator>().enabled = false;

        if (transform.position == destinationPosition) {
            if (dialogue < conversation.transform.childCount)
            {
                child = conversation.transform.GetChild(dialogue);
            }
            animator.SetFloat("Speed",  0);
            dialogueBox.SetActive(true);
            conversation.SetActive(true);
            Conversation();  

     }
     

    }

    void TaskOnClick()
    {

        dialogue++;

        child.GetComponent<CanvasGroup>().alpha = 0f;
        child.GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (dialogue == conversation.transform.childCount)
        {
            move = false;
            destination.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            destination.GetComponent<Animator>().enabled = true;
            dialogueBox.SetActive(false);
            conversation.SetActive(false);
            continueDialogueButton.GetComponent<CanvasGroup>().alpha = 0f;
            continueDialogueButton.GetComponent<CanvasGroup>().interactable = false;
        }
    }

    void Conversation () {
//Impostare i dialoghi visibili
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
