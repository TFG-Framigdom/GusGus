using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  PlayerController : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    private float tiempoMov;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tiempoMov = 0f;
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
        if(moveVelocity == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
            tiempoMov = 0f;

        }else{
            tiempoMov += Time.deltaTime;
            float horizontalVelocity = Mathf.Clamp((moveVelocity.x * speed)/tiempoMov + rb.velocity.x,-speed,speed);
            float verticalVelocity = Mathf.Clamp((moveVelocity.y * speed)/tiempoMov + rb.velocity.y,-speed,speed);
            rb.velocity = new Vector2(horizontalVelocity, verticalVelocity);
        }
    }
}
