using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class PlayerMove2 : MonoBehaviour 
{

    [SerializeField] float speed2 = 3f;
    Rigidbody2D rb2;
    private Vector2 mov2;
    public bool canMove2 = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove2)  // verifico si esta true osea no esta muerto asi puedo moverme.
        {
            Move();
        }
    }
    private void Move()
    {

        mov2.x = Input.GetAxisRaw("Horizontal2") * speed2;
        mov2.y = Input.GetAxisRaw("Vertical2") * speed2;
        rb2.linearVelocity = new Vector2(mov2.x, mov2.y);
    }
}
