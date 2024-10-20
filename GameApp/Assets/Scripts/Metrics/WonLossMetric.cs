using UnityEngine;
using TMPro;

public class WinLossMetricSO : MonoBehaviour
{
    TMP_Text textElement;

    void Awake() {
        textElement = GetComponent<TMP_Text>();

        textElement.text = GetWinStatus();
    }

    private string GetWinStatus()
    {
        // Replace with actual logic
        return "You Won!";
    }
}
