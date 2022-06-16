using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTo : MonoBehaviour
{
    private Vector3 destinationPosition;
    private Vector3 movement;
    public GameObject destination;
    public Rigidbody player;
    private bool firstMove = false;
    private bool dialogueFinished = false;
    public Animator animator;
    float speed = 1f;
    public GameObject dialogueBox;
    public GameObject conversation;
    private int dialogue = 0;
    private Transform child;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(destination.GetComponent<Rigidbody2D>());
        destination.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        destination.GetComponent<Animator>().enabled = false;

        destinationPosition = destination.transform.position;
        destinationPosition.x = destinationPosition.x + 0.2f;
        movement = new Vector3(-1,0,0);
        firstMove = true;
        
    }

    void Update() {
        
        if(firstMove) {
        Move();

        }
        
    }


    void Move() {

     transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed* Time.deltaTime);
     animator.SetFloat("Horizontal", movement.x);
     animator.SetFloat("Speed",  transform.position.sqrMagnitude);

     if (transform.position == destinationPosition) {
        child = conversation.transform.GetChild(dialogue);
        animator.SetFloat("Speed",  0);
        dialogueBox.SetActive(true);
        conversation.SetActive(true);
        Conversation();
        firstMove = false;

     }
     

    }

    void Conversation () {

        if(dialogue == 0){
            child.GetComponent<CanvasGroup>().alpha = 1f;
            child.GetComponent<CanvasGroup>().blocksRaycasts = true;
            destination.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            destination.GetComponent<Animator>().enabled = true;

            
        }
    }

}
