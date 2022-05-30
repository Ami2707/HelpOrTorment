using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    Vector2 rawInput;
    Vector2 position;
    Vector2 mousePosition;
    

    Rigidbody2D myRb;

    public bool isTalkingWithNPC = false;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isTalkingWithNPC)
        {
            Move();
        }
    }

    void Update()
    {
        FaceMouse();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    
    }

    void OnLook(InputValue value)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    void Move()
    {
        position = rawInput * moveSpeed * Time.fixedDeltaTime;
        myRb.MovePosition(myRb.position + position);
        myRb.angularVelocity = 0f;
        myRb.velocity = new Vector2(0f, 0f);
    }

    void FaceMouse()
    {
        transform.right = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
    }

}
