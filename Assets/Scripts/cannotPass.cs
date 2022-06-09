using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider2D))]

public class cannotPass : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    public GameObject Text;
    public GameObject Panel;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }

    protected virtual void Update()
    {
        //Collision work
        boxCollider.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++)
        {

            if (hits[i] == null)
            {
                continue;
            }

            showMessage();



            hits[i] = null;
        }
    }

    protected void showMessage()
    {
        Panel.SetActive(true);
        Text.SetActive(true);
    }


}