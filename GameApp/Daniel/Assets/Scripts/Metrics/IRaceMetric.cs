using TMPro;

public interface IRaceMetric
{
    string MetricName { get; }
    string MetricUnit { get; }
    string CalculateMetric();
}
