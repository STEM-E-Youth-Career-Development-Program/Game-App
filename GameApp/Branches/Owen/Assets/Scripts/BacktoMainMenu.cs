using UnityEngine;
using UnityEngine.SceneManagement; // Correct namespace for SceneManager
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    public Button backToMainMenuButton;

    private void Start()
    {
        // Add listener to button
        backToMainMenuButton.onClick.AddListener(OnBackToMainMenuClicked);
    }

    private void OnBackToMainMenuClicked()
    {
        // Load the "MainMenu" scene
        SceneManager.LoadScene("MainMenu");
    }
}
