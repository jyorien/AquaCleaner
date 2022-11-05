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
        // random mass, gravity and stop time
        float mass = Random.Range(1f, 3f);
        float stopTime = Random.Range(0.1f, 0.3f);
        float gravityScale = Random.Range(1f, 3f);

        rigidBody.mass = mass;
        rigidBody.gravityScale = gravityScale;
        yield return new WaitForSeconds(stopTime);
        rigidBody.gravityScale = 0.1f;
        rigidBody.velocity = new Vector2(0, 0.1f);
        //Destroy(gameObject, 6f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Trash")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), collision.collider);
        }
    }

}
