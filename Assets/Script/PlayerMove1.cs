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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //revisar
        spritePerso = GetComponentInChildren<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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

        mov.x = Input.GetAxisRaw("Horizontal1") * speed;
        mov.y = Input.GetAxisRaw("Vertical1") * speed;
        rb.linearVelocity = new Vector2(mov.x, mov.y);

        anim.SetBool("Walk", mov.x != 0); // control de animacion cuando mueve eje x y ve si no es 0 se cambia

        if (mov.x != 0) // Si el jugador se mueve en el eje horizontal
        {
            spritePerso.flipX = mov.x < 0; // Si se mueve a la izquierda, se voltea (flipX)
        }


    }
}
