using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public Button homeButton;
    // Start is called before the first frame update
    private void Start()
    {
        homeButton.onClick.AddListener(OnHomeClicked);
    }
    private void OnHomeClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
