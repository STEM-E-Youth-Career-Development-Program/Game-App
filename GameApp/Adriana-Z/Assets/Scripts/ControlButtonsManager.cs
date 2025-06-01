using UnityEngine;
using UnityEngine.UI;

public class ControlSchemeManager : MonoBehaviour
{
    public Button wasdButton;
    public Button arrowKeysButton;

    public Sprite wasdButtonActiveImage;
    public Sprite wasdButtonInactiveImage;
    public Sprite arrowKeysButtonActiveImage;
    public Sprite arrowKeysButtonInactiveImage;

    private void Start()
    {
        // Initialize button states
        SetControlScheme("WASD");

        // Add listeners to buttons
        wasdButton.onClick.AddListener(() => SetControlScheme("WASD"));
        arrowKeysButton.onClick.AddListener(() => SetControlScheme("Arrows"));
    }

    private void SetControlScheme(string scheme)
    {
        // Update button images
        if (scheme == "WASD")
        {
            wasdButton.GetComponent<Image>().sprite = wasdButtonActiveImage;
            arrowKeysButton.GetComponent<Image>().sprite = arrowKeysButtonInactiveImage;
        }
        else if (scheme == "Arrows")
        {
            wasdButton.GetComponent<Image>().sprite = wasdButtonInactiveImage;
            arrowKeysButton.GetComponent<Image>().sprite = arrowKeysButtonActiveImage;
        }

        // Save the selected control scheme
        PlayerPrefs.SetString("ControlScheme", scheme);

        // Apply the control scheme
        ApplyControlScheme(scheme);
    }

    private void ApplyControlScheme(string scheme)
    {
        // Logic to switch control schemes
        // Example: Update input mappings or configurations based on the selected scheme
        if (scheme == "WASD")
        {
            // Enable WASD controls
        }
        else if (scheme == "Arrows")
        {
            // Enable Arrow Key controls
        }
    }
}
