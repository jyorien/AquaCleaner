using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BeachItem : MonoBehaviour
{
    const string RECYCLE_BIN = "RecycleBin";
    const string TRASH_BIN = "TrashBin";
    const string EWASTE_BIN = "EWasteBin";
    Vector2 difference = Vector2.zero;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2) transform.position;


    }

    private void OnMouseUp()     
    
    {

        var itemTag = Physics2D.OverlapBoxAll(transform.position, spriteRenderer.bounds.size, 0);
        var wasteTag = gameObject.tag;
        foreach (BoxCollider2D item in itemTag)
        {
            switch (item.tag)
            {
                case RECYCLE_BIN:
                    HandleScoring(wasteTag, "Recyclable");
                    break;
                case TRASH_BIN:
                    HandleScoring(wasteTag, "Trash");
                    break;
                case EWASTE_BIN:
                    HandleScoring(wasteTag, "EWaste");
                    break;
                default:
                    break;
            }

        }


    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }



    void HandleScoring(string itemTag, string trueTag)
    {
        if (itemTag == trueTag)
        {
            GameManager.Instance.AddToBeachScore();
        }
        else
        {
            GameManager.Instance.DeductFromBeachScore();
        }
        Destroy(gameObject);
    }
}
