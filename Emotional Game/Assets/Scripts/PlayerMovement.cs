using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundLayers;
    public Rigidbody2D myRB;
    public SpriteRenderer mySprite;
    private float moveDir;
   [SerializeField] private float moveSpeed, maxSpeed, jumpForce;
    bool canJump = true;



    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponentInChildren<SpriteRenderer>();
        myRB = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {

        if (moveDir > 0)
        {
            mySprite.flipX = false;
        }

        if (moveDir < 0)
        {
            mySprite.flipX = true;
        }

        var moveAxis = Vector3.right * moveDir;

        if (Mathf.Abs(myRB.velocity.x) < maxSpeed)
        {
            myRB.AddForce(moveAxis * moveSpeed, ForceMode2D.Force);
        }

        if (groundCheck.IsTouchingLayers(groundLayers))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        myRB.AddForce(transform.right * moveDir * moveSpeed);

    }


    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Up");
        if (canJump)
        {
            if (context.started)
            {
                myRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
            }
        }

    }

    public void Left(InputAction.CallbackContext context) 
    {
        Debug.Log("Left");
        moveDir = -1;

        if (context.canceled)
        {
            moveDir = 0;
        }
    }

    public void Right(InputAction.CallbackContext context)
    {
        Debug.Log("Right");
        moveDir = 1;

        if (context.canceled)
        {
            moveDir = 0;
        }
    }

}
