using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseScreen : MonoBehaviour
{
    [SerializeField] private List<RaceMetricSO> raceMetrics;
    [SerializeField] private TMP_Text[] textElements;

    private void Start()
    {
        DisplayMetrics();
    }

    private void DisplayMetrics()
    {
        for (int i = 0; i < raceMetrics.Count; i++) {
            RaceMetricSO metric = raceMetrics[i];
            TMP_Text textElement = textElements[i];

            textElement.text = $"{metric.MetricName}: {metric.CalculateMetric()} {metric.MetricUnit}";
        }
    }
}
