using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ChangeScene"))
        {
            SceneManager.LoadScene("Scene4");
        }

        if (other.CompareTag("ChangeScene2"))
        {
            SceneManager.LoadScene("Continue");
        }
    }
    public void playerChange()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void playerChange2()
    {
        Debug.Log("Cambiando a escena Tubes...");
        SceneManager.LoadScene("Tubes");
    }

    public void playerChange3()
    {
        Debug.Log("Cambiando a escena TubesManager...");
        SceneManager.LoadScene("TubesManager");
    }
}
