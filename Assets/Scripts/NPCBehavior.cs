using System.Collections;
using System.Collections.Generic;
using UnityEngine;
     
public class NPCBehavior : MonoBehaviour
{
     
    public Vector3 targetPos1;
    public Vector3 targetPos2;
    public float speed = 1f;
    public bool canMove;
    public bool firstMove;
    public bool moveUpDown = false;
    public bool moveLeftRight = false;
    public Animator animator;
    public Vector3 movement;

    void Start()
    {
       
        firstMove = true;
       
    }
    void Update()
    {
        
        if(transform.position == targetPos1)
        {
            firstMove = false;
        }
        if (transform.position == targetPos2)
        {
            firstMove = true;
        }
        if (canMove)
        {
            if (firstMove)
            {
                if(moveLeftRight) {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos1, speed* Time.deltaTime);
                    animator.SetFloat("Horizontal", movement.x);
                    animator.SetFloat("Speed",  transform.position.sqrMagnitude);
                }
                else {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos1, speed* Time.deltaTime);
                    animator.SetFloat("Vertical", movement.y);
                    animator.SetFloat("Speed",  transform.position.sqrMagnitude);
                }
              
            }
            else
            {      
                if(moveLeftRight) {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos2, speed* Time.deltaTime);
                    movement = transform.position;
                     animator.SetFloat("Horizontal", movement.x);
                    animator.SetFloat("Speed", transform.position.sqrMagnitude);
                    movement.x = movement.x * -1;
                }
                else {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos2, speed* Time.deltaTime);
                    movement = transform.position;
                    animator.SetFloat("Vertical", movement.x);
                    animator.SetFloat("Speed", transform.position.sqrMagnitude);
                    movement.y = movement.y * -1;

                }

                
            }

        }
       
    }
}
