using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Burbujin1 : MonoBehaviour
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

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Apretando d");
            transform.Rotate(0, 0, RotationMoveLeft * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Apretando a");
            transform.Rotate(0, 0, RotationMoveRight * Time.deltaTime);
        }

    }

}