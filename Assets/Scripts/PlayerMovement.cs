using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool facingRight;
    public float speed;
    private float inputX;
    private float inputY;
    public Rigidbody2D rb;
    public Vector2 MoveDirection { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (!Dead())
        {
            GetInputs();
            SetMoveDirection();
            FlipSprite();
        } 
        else
        {
            MoveDirection = Vector2.zero;
        }
    }

    private bool Dead()
    {
        return GetComponent<PlayerDeath>().dead;
    }

    // For physics updates
    public void FixedUpdate()
    {
        MoveFish();
    }

    public void GetInputs()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    public void SetMoveDirection()
    {
        MoveDirection = new Vector2(inputX * speed, inputY * speed);
    }

    public void MoveFish()
    {
        rb.AddForce(MoveDirection);
    }

    // Flip sprite depending on x direction
    public void FlipSprite()
    {
        if (inputX < 0 && facingRight || inputX > 0 && !facingRight)
        {
            transform.Rotate(new Vector2(0,180));
            facingRight = !facingRight;
        }
    }
}
