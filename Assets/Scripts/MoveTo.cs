using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    Interaction interaction;
    public GameObject objectEvent;
    public GameObject colliderEnterTo;
    public Animator animator;
    private Vector3 destinationPosition;
    private Vector3 movement = new Vector3(0, 1, 0);
    private bool readyToStartEvent = false;
    private float speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
       interaction = objectEvent.GetComponent<Interaction>();
       destinationPosition = colliderEnterTo.transform.position;
       
       if(interaction.finish == true) {
        MoveToDirection();
          
       }
    }

    void MoveToDirection()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed* Time.deltaTime);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed",  transform.position.sqrMagnitude);
        
        if (transform.position == destinationPosition) {
            Destroy(objectEvent);
            interaction.finish = false;
        }
        
    }
}   
