using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
public class PlayerMove2 : MonoBehaviour
{

    [SerializeField] float speed = 3f;
    Rigidbody2D rb;
    private Vector2 mov;
    public bool canMove = true;

    private Animator anim;
    private SpriteRenderer spritePerso;
    // Variable para recordar la última dirección de movimiento
    private bool lastMoveLeft = false;

    public GameObject hijo;
    private SpriteRenderer spriteRenderer;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //revisar
        spritePerso = GetComponentInChildren<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        spriteRenderer = hijo.GetComponent<SpriteRenderer>();



    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)  // verifico si esta true osea no esta muerto asi puedo moverme.
        {
            Move();
        }
    }
    private void Move()
    {

        mov.x = Input.GetAxisRaw("Horizontal2") * speed;
        mov.y = Input.GetAxisRaw("Vertical2") * speed;
        rb.linearVelocity = new Vector2(mov.x, mov.y);


        if (mov.x == 0)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("WalkBack", false);

            if (lastMoveLeft)
            {
               anim.SetBool("Left", true);
               anim.SetBool("HamsterStop", false);
            }
            else
            {
                anim.SetBool("HamsterStop", true); // Si no fue hacia la izquierda, ponemos el estado quieto normal
                anim.SetBool("HamsterStopLeft", false);
            }
        }


        if (mov.x != 0) // Si el jugador se mueve en el eje horizontal
        {
           if (mov.x > 0)
           {
                anim.SetBool("Walk", true);
                anim.SetBool("WalkBack", false);  // Desactiva la animación de caminar hacia atrás}}
                anim.SetBool("Left", false);  // Activa la animación de quieto mirando hacia la izquierda
                lastMoveLeft = false; // Recordamos que el último movimiento no fue hacia la izquierda
           }
           if (mov.x < 0)
           {
                Debug.Log("entro");
                anim.SetBool("WalkBack", true);
                anim.SetBool("Walk", false); // Desactiva la animación de caminar hacia adelante
                anim.SetBool("Left", true);  // Activa la animación de quieto mirando hacia la izquierda
                lastMoveLeft = true; // Recordamos que el último movimiento fue hacia la izquierda
           }
        }
    }
    private void OnTriggerStay2D(Collider2D Stair)
    {
        Debug.Log("Adentro");
        if (Stair.CompareTag("Subir"))
        {
            anim.SetBool("Up", true);
        }
        if (Stair.CompareTag("tubo"))
        {
            anim.SetBool("Right", false);
            anim.SetBool("Up", true);
            spriteRenderer.enabled = false;
            Debug.Log("SpriteRenderer desactivado.");

        }
        if (Stair.CompareTag("tuboRect"))
        {
            anim.SetBool("Up", false);
            spriteRenderer.enabled = false;
            Debug.Log("SpriteRenderer desactivado.");
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("salio");
        anim.SetBool("Up", false);
        spriteRenderer.enabled = true;
        Debug.Log("SpriteRenderer activado.");
    }
}




    



