using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();  // Llama al método para reiniciar la escena
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;  // Pausa el juego
        isPaused = true;
        // Aquí puedes mostrar el menú de pausa o cualquier UI relacionada
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;  // Reanuda el juego
        isPaused = false;
        // Oculta el menú de pausa o UI relacionada
    }

    void RestartScene()
    {
        // Recarga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
