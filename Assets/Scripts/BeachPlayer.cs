using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachPlayer : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    [SerializeField] Animator animator;
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
        if ( Input.GetKeyDown(KeyCode.W))
        {
            backward = true;
            left = right = forward = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            forward = right = backward = false;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            forward = true;
            left = right = backward   = false;
        }
        else if (Input.GetKeyDown(KeyCode.D))
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
        //if (!IsOutOfBounds(newPosition))
            rb.MovePosition(newPosition);
    }
}
