using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) LoadMainMenu();
    }
}
