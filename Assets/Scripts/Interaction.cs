using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    private Vector3 destinationPosition;
    private Vector3 movement;
    public bool firstMove = false;
    public bool speak = false;
    public GameObject destination;
    public GameObject player;
    public bool finishSpeak = false;
    public bool move = false;
    public Animator animator;
    float speed = 1f;
    public Collider2D  NPC_collision;
    public GameObject dialogueBox;
    public GameObject conversation;
    public bool finish = false;
    private int dialogue = 0;
    private Transform child;
    public UnityEngine.UI.Button continueDialogueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (firstMove)
        {
            destination.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            destination.GetComponent<Animator>().enabled = false;

            destinationPosition = destination.transform.position;
            destinationPosition.x = destinationPosition.x + 0.2f;
            movement = new Vector3(-1, 0, 0);
            continueDialogueButton.onClick.AddListener(TaskOnClick);
        }
        

    }

    void Update() {
        
        if(move||firstMove) {
            Move();

        }

        else if (!speak)
        {
            SetMovement();
        }
        else
        {
            destinationPosition = destination.transform.position;
            Speak();
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

    void Speak()
    {

            if (dialogue < conversation.transform.childCount)
            {
                child = conversation.transform.GetChild(dialogue);
            }
            dialogueBox.SetActive(true);
            conversation.SetActive(true);
            Conversation();

        
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == NPC_collision.name)
        {
            destination.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            destination.GetComponent<Animator>().enabled = false;
            continueDialogueButton.onClick.AddListener(TaskOnClick);

            if (dialogue < conversation.transform.childCount)
            {
                child = conversation.transform.GetChild(dialogue);
            }
            dialogueBox.SetActive(true);
            conversation.SetActive(true);
            Conversation();
            speak = true;
            if (!speak)
            {
                animator.SetFloat("Speed", 0);
            }
            if (this.name == "esben2")
            {
                GameObject.Find("colliderToEnter(Taverna)").GetComponent<BoxCollider2D>().enabled = true;
                if (GameObject.Find("fiaccola") != null)
                {
                    GameObject.Find("fiaccola").GetComponent<BoxCollider2D>().enabled = true;
                }

            }
            if (this.name == "altare")
            {
                GameObject.Find("collideruscita").GetComponent<BoxCollider2D>().enabled = true;
                GameObject.Find("colliderToEnter(Tempio)").GetComponent<BoxCollider2D>().enabled = false;

            }
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
            speak = false;
            dialogueBox.SetActive(false);
            conversation.SetActive(false);
            firstMove = false;
            finish = true;
            continueDialogueButton.GetComponent<CanvasGroup>().alpha = 0f;
            continueDialogueButton.GetComponent<CanvasGroup>().interactable = false;
           
        }
        
    }

    void SetMovement()
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        player.GetComponent<Animator>().enabled = true;
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
        else if (dialogue == 2)
        {
            child.GetComponent<CanvasGroup>().alpha = 1f;
            child.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else if (dialogue == 3)
        {
            child.GetComponent<CanvasGroup>().alpha = 1f;
            child.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else if (dialogue == 4)
        {
            child.GetComponent<CanvasGroup>().alpha = 1f;
            child.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else if (dialogue == 5)
        {
            child.GetComponent<CanvasGroup>().alpha = 1f;
            child.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

}
