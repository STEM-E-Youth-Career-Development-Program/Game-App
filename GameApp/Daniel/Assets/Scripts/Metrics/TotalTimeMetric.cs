using UnityEngine;
using TMPro;

public class TotalTimeMetricSO : MonoBehaviour
{
    TMP_Text textElement;

    void Awake() {
        textElement = GetComponent<TMP_Text>();

        textElement.text = GetWinStatus();
    }

    private string secondsFormatter(int totalSeconds) {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        return minutes + ":" + (seconds == 0 ? "00" : seconds);
    }

    private string GetWinStatus()
    {
        // Replace with actual logic
        return secondsFormatter(225);
    }
}
