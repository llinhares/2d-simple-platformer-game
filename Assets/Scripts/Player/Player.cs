using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speed = 10f;

    public float jumpForce = 2f;
    void Update()
    {
        HandleJump();
        HandleMovements();
    }

    private void HandleMovements()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
        }

        if(myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        } else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;
        }
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            myRigidbody.velocity = Vector2.up * jumpForce;
        }
    }
}
