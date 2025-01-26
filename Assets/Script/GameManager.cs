using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
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
}
