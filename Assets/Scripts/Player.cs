using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    Rigidbody2D rb;
    float HorizontalMovement;
    float VerticalMovement;
    float PlayerRadius = 1;

    [SerializeField] TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement = Input.GetAxisRaw("Horizontal");
        VerticalMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        DetectTrash(GetPlayerCenter(), PlayerRadius);
        MovePlayer();
    }

    private void OnDrawGizmos()
    {
        // score area gizmos
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(GetPlayerCenter(), PlayerRadius);
    }

    // player controls
    void MovePlayer()
    {
        if (HorizontalMovement != 0 && Mathf.Abs(rb.rotation) < 30f)
        {
            rb.rotation+= -0.3f * HorizontalMovement;
        }
        else
        {
            if (rb.rotation > 0f)
            {
                rb.rotation -= 0.8f;
            }
            else
            {
                rb.rotation += 0.8f;
            }
        }
        var movementInput = new Vector2(HorizontalMovement, VerticalMovement);
        var velo = movementInput * MovementSpeed;
        rb.MovePosition((Vector2)transform.position + (velo * Time.deltaTime));
    }

    void DetectTrash(Vector3 center, float radius)
    {
        // detect score area
        Collider2D[] colliders = Physics2D.OverlapCircleAll(center, radius);
        Collider2D[] trashColliders = colliders.Where(col => col.CompareTag("Trash")).ToArray();
        UpdateScoreElements(trashColliders.Length);
    }

    void UpdateScoreElements(int score)
    {
        GameManager.Instance.UpdateScore(score);
        scoreText.text = $"{GameManager.Instance.GetCurrentScore():D4}";
    }

    Vector3 GetPlayerCenter()
    {
        return transform.position;
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
}
