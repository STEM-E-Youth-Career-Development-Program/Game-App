using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public Button settingsButton;
    // Start is called before the first frame update
    private void Start()
    {
        settingsButton.onClick.AddListener(OnSettingsClicked);
    }
    private void OnSettingsClicked()
    {
        SceneManager.LoadScene("SettingsScreen");
    }
}
