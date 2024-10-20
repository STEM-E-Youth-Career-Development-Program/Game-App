using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public bool rainy{ get; private set; }

    public void ChangeWeather()
    {
        rainy = !rainy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
