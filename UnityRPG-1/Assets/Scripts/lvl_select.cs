using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl_select : MonoBehaviour
{
    // Method to start the game (load the main game scene)
    public void lvlselect_Desert()
    {
        // Assuming your main game scene is called "GameScene"
        SceneManager.LoadScene("DesertMap");
    }
    public void lvlselect_Temp_1()
    {
        // Assuming your main game scene is called "GameScene"
        SceneManager.LoadScene("Temp_1");
    }
        public void lvlselect_Temp_2()
    {
        // Assuming your main game scene is called "GameScene"
        SceneManager.LoadScene("Temp_2");
    }
        public void lvlselect_Temp_3()
    {
        // Assuming your main game scene is called "GameScene"
        SceneManager.LoadScene("Temp_3");
    }

    // Method to quit the game
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}