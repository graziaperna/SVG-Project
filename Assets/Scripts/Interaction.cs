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
    public bool move = false;
    public Animator animator;
    float speed = 1f;
    public Collider2D NPC_collision;
    public GameObject dialogueBox;
    public GameObject conversation;
    public GameObject gObjInv;
    public GameObject InventoryBox;
    public GameObject slotGObjToGive;
    public bool finish = false;
    private int dialogue = 0;
    private Transform child;
    public UnityEngine.UI.Button continueDialogueButton;
    InventorySystem inventory;
    public bool give = false;
    private float tempo = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (firstMove)
        {
            if(this.name == "esben") {
                destination.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                destination.GetComponent<Animator>().enabled = false;

                destinationPosition = destination.transform.position;
                destinationPosition.x = destinationPosition.x + 0.2f;
                movement = new Vector3(-1, 0, 0);
                continueDialogueButton.onClick.AddListener(TaskOnClick);
            } else if(this.name == "freya")
            {
                SetTheConversation();
            }
            

        }
 
        if (give)
        {
            inventory = gObjInv.GetComponent<InventorySystem>();
        }

    }

    void Update() {

        if (give)
        {
            inventory.ManageTime();
        }


        if ((move || firstMove) && this.name == "esben") {
            Move();

        }
        if (speak)
        {
            destinationPosition = destination.transform.position;
            Speak();
    
        }


    }


    static GameObject FindByName(string goName)
    {
        GameObject go = null;

        foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (obj.name.Equals(goName))
            {
                Debug.Log(obj.name);
                go = obj;
                return go;
            }
        }

        return null;
    }



    void Move() {

        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed * Time.deltaTime);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", transform.position.sqrMagnitude);

        destination.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        destination.GetComponent<Animator>().enabled = false;

        if (transform.position == destinationPosition) {
            if (dialogue < conversation.transform.childCount)
            {
                child = conversation.transform.GetChild(dialogue);
            }
            animator.SetFloat("Speed", 0);
            dialogueBox.SetActive(true);
            conversation.SetActive(true);
            Conversation();

        }


    }


    void Speak()
    {
        if (!finish)
        {
            child = conversation.transform.GetChild(dialogue);
            Conversation();
        } else
        {
           
            Interaction interaction = this.GetComponent<Interaction>();

            if (speak)
            {
                interaction.speak = false;
            } else if(move)
            {
                interaction.move = false;
            }
            else if (firstMove)
            {
                interaction.firstMove = false;
            }

            dialogueBox.SetActive(false);
            conversation.SetActive(false);
            EnableMovement();
        }

    }

    void SetTheConversation()
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

        speak = true;
        move = false;
        firstMove = false;

        if (!speak)
        {
            animator.SetFloat("Speed", 0);
        }
        if (this.name == "esben2")
        {
            GameObject obj1 = GameObject.FindWithTag("enableColliderTaverna");
            obj1.GetComponent<BoxCollider2D>().enabled = true;

            inventory.slot = slotGObjToGive;
            inventory.Inventory = InventoryBox;
            inventory.tempo = tempo;
            inventory.addItem();

        }
        else if (this.name == "altare")
        {
            GameObject obj1 = GameObject.FindWithTag("disableColliderTempio");
            obj1.GetComponent<BoxCollider2D>().enabled = false;

            GameObject obj2 = GameObject.FindWithTag("esben2");
            obj2.GetComponent<SpriteRenderer>().enabled = true;
            obj2.GetComponent<BoxCollider2D>().enabled = true;

        }
        else if (this.name == "harald")
        {
            GameObject obj1 = GameObject.FindWithTag("enableDiary");
            obj1.GetComponent<CanvasGroup>().interactable = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == NPC_collision.name)
        {
            SetTheConversation();
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
            firstMove = false;
            dialogueBox.SetActive(false);
            conversation.SetActive(false);
            finish = true;
            continueDialogueButton.GetComponent<CanvasGroup>().alpha = 0f;
            continueDialogueButton.GetComponent<CanvasGroup>().interactable = false;
            child.GetComponent<CanvasGroup>().alpha = 0f;
            child.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        
    }

    void EnableMovement()
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
        else if (dialogue == 6)
        {
            child.GetComponent<CanvasGroup>().alpha = 1f;
            child.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else if (dialogue == 7)
        {
            child.GetComponent<CanvasGroup>().alpha = 1f;
            child.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

}
