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
    private Vector3 scaleChange;
    public GameObject slot;
    private UnityEngine.UI.Text added;
    float tempo = 0;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        added = GameObject.FindWithTag("addedItem").GetComponent<UnityEngine.UI.Text>();
        for (int i = 0; i < 11; i++)
        {
            empty[i] = true;
        }

    }

    protected virtual void Update()
    {
        tempo += Time.deltaTime; 
        //Collision work
        boxCollider.OverlapCollider(filter, hits);

        if (tempo >= 2f)
        {
            added.GetComponent<CanvasGroup>().alpha = 0f;
            tempo = 0f;
        }

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
    
    public void addItem()
    {
        scaleChange = new Vector3(7f, 7f, 7f);
        GameObject newSlot = Instantiate(slot, Inventory.transform);
        added.GetComponent<CanvasGroup>().alpha = 1f;
       

    }

}