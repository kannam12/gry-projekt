using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveInChest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openedChest;
    public Sprite closedChest;
    public GameObject chestObj;

    void Start() {
        //chestObj = GameObject.Find("Chest");
        //spriteRenderer = chestObj.GetComponent<spriteRenderer>();
        //Debug.Log("importowaned");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Chest")
        {
            Debug.Log("opening chest...");
            spriteRenderer.sprite = openedChest;            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Chest")
        {
            Debug.Log("closing chest...");
            spriteRenderer.sprite = closedChest;            
        }
    }
}
