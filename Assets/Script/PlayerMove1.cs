using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class PlayerMove1 : MonoBehaviour 
{

    [SerializeField] float speed = 3f;
    Rigidbody2D rb;
    private Vector2 mov;
    public bool canMove = true;

    private Animator anim;
    private SpriteRenderer spritePerso;

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

        mov.x = SimpleInput.GetAxisRaw("Horizontal1") * speed;
        mov.y = SimpleInput.GetAxisRaw("Vertical1") * speed;
        rb.linearVelocity = new Vector2(mov.x, mov.y);

        anim.SetBool("Walk", mov.x != 0); // control de animacion cuando mueve eje x y ve si no es 0 se cambia

        if (mov.x != 0) // Si el jugador se mueve en el eje horizontal
        {
            spritePerso.flipX = mov.x < 0; // Si se mueve a la izquierda, se voltea (flipX)
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
        /*if (Stair.CompareTag("tuboRect")) ESTO SIRVE PARA VISTA TOP DOWN DE COSTADO no necesario ahora al final
        {
            anim.SetBool("Up", false);
            anim.SetBool("Right", true);
            spriteRenderer.enabled = false;
            Debug.Log("SpriteRenderer desactivado.");

        }
        */

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("salio");
        anim.SetBool("Up", false);
        spriteRenderer.enabled = true;
        Debug.Log("SpriteRenderer activado.");
    }
}
