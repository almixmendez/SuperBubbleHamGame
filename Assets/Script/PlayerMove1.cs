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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
}
