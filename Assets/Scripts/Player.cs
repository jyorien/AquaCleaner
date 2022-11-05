using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    Rigidbody2D rb;
    float horizontalMovement;
    float verticalMovement;

    [SerializeField] TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //DetectTrash(GetPlayerCenter(), 1);

        if (horizontalMovement == 0 && verticalMovement == 0)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        var movementInput = new Vector2(horizontalMovement, verticalMovement);
        var velo = movementInput * MovementSpeed;
        rb.MovePosition((Vector2) transform.position + (velo * Time.deltaTime));
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    string tag = collision.collider.gameObject.tag;
    //    if (tag == "Trash") {
    //        GameManager.Instance.AddToScore(1);
    //        scoreText.text = $"{GameManager.Instance.GetCurrentScore():D4}";
    //        Destroy(collision.gameObject);
    //    }
    //}

    //void DetectTrash(Vector3 center, float radius)
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(center, radius);
    //    Debug.Log(hitColliders.Length);
    //}

    //Vector3 GetPlayerCenter()
    //{
    //    return gameObject.transform.position;
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.cyan;
    //    Gizmos.DrawWireSphere(GetPlayerCenter(), 1);
    //}
}
