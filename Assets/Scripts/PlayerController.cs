using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  PlayerController : MonoBehaviour
{

    public float speed = 15f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    

    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Debug.Log("Hola Mundo");
        gameObject.GetComponent<Transform>().position = new Vector3(-6.5f, 23f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveVelocity = new Vector2(moveX, moveY);


        // if(Input.GetKey("left"))
        // {
        //     gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0));
        // }
        // if(Input.GetKey("right"))
        // {
        //     gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0));
        // }
        // if(Input.GetKey("up"))
        // {
        //     gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1));
        // }
        // if(Input.GetKey("down"))
        // {
        //     gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1));
        // }
    }

    void FixedUpdate()
    {
        float horizontalVelocity = moveVelocity.x * speed;
        float verticalVelocity = moveVelocity.y * speed;
        rb.velocity = new Vector2(horizontalVelocity, verticalVelocity);
    }
}
