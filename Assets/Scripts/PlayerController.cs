using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  PlayerController : MonoBehaviour
{

    public float speed = 15f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<Transform>().position = new Vector3(-6.5f, 23f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveVelocity = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        float horizontalVelocity = moveVelocity.x * speed ;
        float verticalVelocity = moveVelocity.y * speed ;
        rb.velocity = new Vector2(horizontalVelocity, verticalVelocity);
    }
}
