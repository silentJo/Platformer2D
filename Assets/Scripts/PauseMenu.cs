using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
                PlayerMovement.instance.enabled = false;
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
            }
            else Resume();
        }
    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
