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
    public float tempo = 0;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        for (int i = 0; i < 11; i++)
        {
            empty[i] = true;
        }

    }

    public void ManageTime()
    {
        added = GameObject.FindWithTag("addedItem").GetComponent<UnityEngine.UI.Text>();
        tempo += Time.deltaTime;

        if (tempo >= 2f)
        {
            added.GetComponent<CanvasGroup>().alpha = 0f;
            tempo = 0f;
        }
    }

    protected virtual void Update()
    {
        ManageTime();
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
    
    public void addItem()
    {
        added = GameObject.FindWithTag("addedItem").GetComponent<UnityEngine.UI.Text>();
        scaleChange = new Vector3(7f, 7f, 7f);
        GameObject newSlot = Instantiate(slot, Inventory.transform);

        tempo = 0f;
        added.GetComponent<CanvasGroup>().alpha = 1f;

    }

}