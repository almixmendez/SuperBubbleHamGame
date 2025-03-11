using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; // Aseg�rate de tener esto para manejar escenas

public class ButtonImageChange : MonoBehaviour
{
    public Button myButton; // El bot�n en el que quieres cambiar la imagen
    public Sprite image1; // La primera imagen
    public Sprite image2; // La segunda imagen
    private Image buttonImage; // Imagen del bot�n
    private bool isChanging = false; // Controla si el cambio de imagen est� en curso
    public string sceneName = "SceneName"; // El nombre de la escena que quieres cargar

    void Start()
    {
        // Obt�n la imagen del bot�n
        buttonImage = myButton.GetComponent<Image>();

        // Agregar un evento al bot�n cuando se haga clic
        myButton.onClick.AddListener(ChangeImage);
    }

    // Funci�n que cambia la imagen de forma intercalada
    void ChangeImage()
    {
        // Si ya est� cambiando, no hagas nada
        if (isChanging) return;

        // Comienza la corutina para alternar las im�genes
        StartCoroutine(AlternateImages());
    }

    // Corutina que intercambia entre las dos im�genes varias veces
    IEnumerator AlternateImages()
    {
        isChanging = true;

        int changeCount = 5; // N�mero de veces que queremos alternar
        float changeInterval = 0.2f; // Intervalo entre cada cambio de imagen

        for (int i = 0; i < changeCount; i++)
        {
            // Alterna la imagen entre image1 y image2
            buttonImage.sprite = (i % 2 == 0) ? image1 : image2;
            yield return new WaitForSeconds(changeInterval); // Espera un tiempo antes de cambiar nuevamente
        }

        // Aseg�rate de que la imagen final sea image1 o image2 seg�n el �ltimo estado
        buttonImage.sprite = image1;

        // Carga la escena despu�s de completar el cambio de im�genes
        ChangeScene();

        isChanging = false; // Finaliza el proceso de cambio de im�genes
    }

    // Funci�n para cambiar la escena
    private void ChangeScene()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene("scene1"); // Aseg�rate de que el nombre de la escena sea correcto
    }
}
