using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // Method to start the game (load the main game scene)
    public void StartGame()
    {
        // Assuming your main game scene is called "GameScene"
        SceneManager.LoadScene("SelectScreen");
    }

    // Method to quit the game
    public void QuitGame()
    {
        // Quit the application (only works in a build)
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
