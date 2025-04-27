using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "TopSpeedMetric", menuName = "Racing/Metrics/Top Speed")]
public class TopSpeedMetricSO : RaceMetricSO
{
    public override string MetricName => "Top Speed";
    public override string MetricUnit => "mph";

    public override string CalculateMetric()
    {
        return GetTopSpeed();
    }

    private string GetTopSpeed()
    {
        // Replace with actual logic
        return "120";
    }
}
