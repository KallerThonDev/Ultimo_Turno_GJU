
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    // Método para iniciar el juego
    public void StartGame()
    {
        SceneManager.LoadScene("Fase1_Mapa"); // Asegúrate de que "GameScene" es el nombre correcto
    }

    // Método para salir del juego
    public void QuitGame()
    {
        Application.Quit();
    }
}
