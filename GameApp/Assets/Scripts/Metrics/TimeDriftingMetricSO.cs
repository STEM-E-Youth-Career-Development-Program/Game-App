using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "TimeDriftingMetric", menuName = "Racing/Metrics/Time Drifting")]
public class TimeDriftingMetricSO : RaceMetricSO
{
    public override string MetricName => "Time Drifting";
    public override string MetricUnit => "secs";

    public override string CalculateMetric()
    {
        return GetTimeDrifting();
    }

    private string GetTimeDrifting()
    {
        // Replace with actual logic
        return "120";
    }
}
