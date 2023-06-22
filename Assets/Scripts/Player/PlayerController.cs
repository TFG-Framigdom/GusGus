using System.Collections;
using UnityEngine;

public class  PlayerController : MonoBehaviour
{

    public float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public bool isMovementEnabled = true;
    private float tiempoMov;

    public LecturaFicheroSO lectura;

    public GameObject player;
    private bool vulnerable = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tiempoMov = 0f;
        //PlayerSpawner();
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
            tiempoMov = 0f;
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
                //float horizontalVelocity = Mathf.Clamp((moveVelocity.x * speed),-speed,speed);
                float verticalVelocity = Mathf.Clamp((moveVelocity.y * speed)/tiempoMov + rb.velocity.y,-speed,speed);
                rb.velocity = new Vector2(horizontalVelocity, verticalVelocity);
            }
        }else{
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            tiempoMov = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyBasic" && vulnerable)
        {
            isMovementEnabled = false;
            //si el player esta activo
            PlayerStadistic playerStadistics = FindObjectOfType<PlayerStadistic>();
            playerStadistics.PlayerDamage();
            vulnerable = false;
            if(this.gameObject.activeSelf)
            StartCoroutine(EnablePlayerControlAfterDelay(1f));
            
            
        }else if(other.gameObject.tag == "ItemTiempo"){
            TimeController tiempo =  FindObjectOfType<TimeController>();
            tiempo.ItemTimer(15);
            
            Destroy(other.gameObject);

        }else if(other.gameObject.tag == "ItemVida"){
            PlayerStadistic playerStadistics = FindObjectOfType<PlayerStadistic>();
            playerStadistics.PlayerHealth();
            Destroy(other.gameObject);

        }else if(other.gameObject.tag == "ItemPunto"){
            PointController puntos = FindObjectOfType<PointController>();
            puntos.SumarPuntos(25);
            Destroy(other.gameObject);
        }
    }

    IEnumerator EnablePlayerControlAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        isMovementEnabled = true;
        vulnerable = true;
    }

    public void PlayerSpawner(){
        if(player.transform.position != lectura.posicionJugador)
        {
            player.transform.position = lectura.posicionJugador;
        }
        Debug.Log(player.transform.position + " --------------------------");
    }
}
