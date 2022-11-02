using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float MovementSpeed = 2;
    float JumpForce = 5;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.gameObject.tag;
        if (tag == "Trash") {
            GameManager.Instance.AddToScore(1);
            Destroy(collision.gameObject);
        }
    }
}
