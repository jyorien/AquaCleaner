using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
      

        StartCoroutine(StopTrash());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StopTrash()
    {
        yield return new WaitForSeconds(0.5f);
        rigidBody.gravityScale = 0;

        rigidBody.velocity = Vector2.zero;
    }

}
