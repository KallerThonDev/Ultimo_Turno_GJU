
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    // Método para iniciar el juego
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Asegúrate de que "GameScene" es el nombre correcto de tu escena de juego
    }

    // Método para salir del juego
    public void QuitGame()
    {
        Application.Quit();
    }
}
