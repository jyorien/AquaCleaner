using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachPlayer : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D LeftBoundary;
    [SerializeField] BoxCollider2D RightBoundary;
    [SerializeField] BoxCollider2D BottomBoundary;
    float HorizontalMovement;
    float VerticalMovement;
    bool left, right, forward, backward = false;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OpenDialog(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement = Input.GetAxisRaw("Horizontal");
        VerticalMovement = Input.GetAxisRaw("Vertical");
        if ( Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            backward = true;
            left = right = forward = false;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left = true;
            forward = right = backward = false;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            forward = true;
            left = right = backward   = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            right = true;
            left = forward = backward = false;
        }


    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 movementInput = new Vector2(0,0);
        if (left || right)
        {
            movementInput = new Vector2(HorizontalMovement, 0);
            animator.SetFloat("Horizontal", HorizontalMovement);
            animator.SetFloat("Vertical", 0);

        }
        else if (forward || backward)
        {
            movementInput = new Vector2(0, VerticalMovement);
            animator.SetFloat("Vertical", VerticalMovement);
            animator.SetFloat("Horizontal", 0);
        }

   
        var velo = movementInput * MovementSpeed;
        var newPosition = (Vector2)transform.position + (velo * Time.deltaTime);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.2f);
        bool isCollide = false;
        foreach (Collider2D collider in colliders)
        {
            string name = collider.name;
            if (name == "Toddie" || name == "Ms Gaia" || name == "Hermie" || name == "Classmate" || name == "Grid" || name == "Left Boundary" || name == "Right Boundary" || name == "Bottom Boundary")
            {
                isCollide = true;
            }
        }
        //if (!IsOutOfBounds(newPosition))
        if (!isCollide) 
            rb.MovePosition(newPosition);
    }

    private void OnDrawGizmos()
    {
        // score area gizmos
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 0.2f);
    }

}
