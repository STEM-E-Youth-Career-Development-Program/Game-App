using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Button restartButton;
    // Start is called before the first frame update
    private void Start()
    {
        restartButton.onClick.AddListener(OnRestartClicked);
    }
    private void OnRestartClicked()
    {
        SceneManager.LoadScene("RaceScreen");
    }
}
