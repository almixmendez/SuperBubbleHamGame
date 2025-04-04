using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scriptMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Test");
    }
    public void SecretLevel()
    {
        //     SceneManager.LoadScene("");
    }

}
