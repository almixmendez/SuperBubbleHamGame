using System.Collections;
using System.Collections.Generic;
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

        mov.x = Input.GetAxisRaw("Horizontal2") * speed;
        mov.y = Input.GetAxisRaw("Vertical2") * speed;
        rb.linearVelocity = new Vector2(mov.x, mov.y);


        if (mov.x == 0)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("WalkBack", false);
        }

        if (mov.x != 0) // Si el jugador se mueve en el eje horizontal
        {
            if (mov.x > 0)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("WalkBack", false);  // Desactiva la animación de caminar hacia atrás
            }
            if (mov.x < 0)
            {
                Debug.Log("entro");
                anim.SetBool("WalkBack", true);
                anim.SetBool("Walk", false); // Desactiva la animación de caminar hacia adelante
            }

        }


    }
}


