using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Burbujin2 : MonoBehaviour
{

    private Vector2 mov;
    public float RotationMoveLeft = -200f;
    public float RotationMoveRight = 200f;
    void Start()
    {

    }
    void Update()
    {
        Rotation();
    }
        private void Rotation()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Apretando Right");
            transform.Rotate(0, 0, RotationMoveLeft * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Apretando Left");
            transform.Rotate(0, 0, RotationMoveRight * Time.deltaTime);
        }

    }
}