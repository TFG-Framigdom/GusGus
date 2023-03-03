using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  PlayerController : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private bool isMovementEnabled = true;
    private float tiempoMov;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tiempoMov = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovementEnabled)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            moveVelocity = new Vector2(moveX, moveY).normalized;
        }else{
            moveVelocity = Vector2.zero;
        }
        
    }

    void FixedUpdate()
    {
        if(isMovementEnabled){
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
        }else{
            rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyBasic")
        {
            isMovementEnabled = false;
            //si el player esta activo
            if(this.gameObject.activeSelf)
            StartCoroutine(EnablePlayerControlAfterDelay(1f));
        }
    }

    IEnumerator EnablePlayerControlAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        isMovementEnabled = true;
    }
}
