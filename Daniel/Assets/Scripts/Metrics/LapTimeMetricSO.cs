using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "LapTimeMetric", menuName = "Racing/Metrics/Lap Time")]
public class LapTimeMetricSO : RaceMetricSO
{
    public override string MetricName => $"Lap {lapNumber} Time";
    public override string MetricUnit => "";
    
    [SerializeField] private int lapNumber;

    public override string CalculateMetric()
    {
        return GetLapTime();
    }

    private string secondsFormatter(int totalSeconds) {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        return minutes + ":" + (seconds == 0 ? "00" : seconds);
    }

    private string GetLapTime()
    {
        // Replace with actual logic
        return secondsFormatter(130);
    }
}
