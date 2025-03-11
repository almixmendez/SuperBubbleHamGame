using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; // Asegúrate de tener esto para manejar escenas

public class ButtonImageChange : MonoBehaviour
{
    public Button myButton; // El botón en el que quieres cambiar la imagen
    public Sprite image1; // La primera imagen
    public Sprite image2; // La segunda imagen
    private Image buttonImage; // Imagen del botón
    private bool isChanging = false; // Controla si el cambio de imagen está en curso
    public string sceneName = "SceneName"; // El nombre de la escena que quieres cargar

    void Start()
    {
        // Obtén la imagen del botón
        buttonImage = myButton.GetComponent<Image>();

        // Agregar un evento al botón cuando se haga clic
        myButton.onClick.AddListener(ChangeImage);
    }

    // Función que cambia la imagen de forma intercalada
    void ChangeImage()
    {
        // Si ya está cambiando, no hagas nada
        if (isChanging) return;

        // Comienza la corutina para alternar las imágenes
        StartCoroutine(AlternateImages());
    }

    // Corutina que intercambia entre las dos imágenes varias veces
    IEnumerator AlternateImages()
    {
        isChanging = true;

        int changeCount = 5; // Número de veces que queremos alternar
        float changeInterval = 0.2f; // Intervalo entre cada cambio de imagen

        for (int i = 0; i < changeCount; i++)
        {
            // Alterna la imagen entre image1 y image2
            buttonImage.sprite = (i % 2 == 0) ? image1 : image2;
            yield return new WaitForSeconds(changeInterval); // Espera un tiempo antes de cambiar nuevamente
        }

        // Asegúrate de que la imagen final sea image1 o image2 según el último estado
        buttonImage.sprite = image1;

        // Carga la escena después de completar el cambio de imágenes
        ChangeScene();

        isChanging = false; // Finaliza el proceso de cambio de imágenes
    }

    // Función para cambiar la escena
    private void ChangeScene()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene("scene1"); // Asegúrate de que el nombre de la escena sea correcto
    }
}
