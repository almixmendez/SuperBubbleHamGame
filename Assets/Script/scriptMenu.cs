using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scriptMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void SecretLevel()
    {
        //     SceneManager.LoadScene("");
    }

}
