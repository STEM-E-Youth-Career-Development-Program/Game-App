using UnityEngine;
using TMPro;

public abstract class RaceMetricSO : ScriptableObject, IRaceMetric
{
    public abstract string MetricName { get; }
    public abstract string MetricUnit { get; }
    public abstract string CalculateMetric();
}
