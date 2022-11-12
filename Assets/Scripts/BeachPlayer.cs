using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachPlayer : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    float HorizontalMovement;
    float VerticalMovement;
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
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        var movementInput = new Vector2(HorizontalMovement, VerticalMovement);
        var velo = movementInput * MovementSpeed;
        var newPosition = (Vector2)transform.position + (velo * Time.deltaTime);
        //if (!IsOutOfBounds(newPosition))
            rb.MovePosition(newPosition);
    }
}
