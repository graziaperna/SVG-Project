using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider2D))]

public class InventorySystem : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    public GameObject Inventory;
    private bool[] empty = new bool[11];
    int index = 0;
    private Vector3 scaleChange;
    public GameObject slot;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        for (int i = 0; i < 11; i++)
        {
            empty[i] = true;
        }

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

            Destroy(gameObject);
            addItem();
            


            hits[i] = null;
        }
    }

    protected void addItem()
    {
        scaleChange = new Vector3(7f, 7f, 7f);
        gameObject.transform.localScale = scaleChange;
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -382);
        GameObject newSlot = Instantiate(slot, Inventory.transform);
    }


}