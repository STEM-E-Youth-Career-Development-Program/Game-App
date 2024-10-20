using UnityEngine;
using UnityEngine.Events;

public class WeatherChanger : MonoBehaviour
{
    public UnityEvent slip;
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            slip.Invoke();
        }
    }

    public void Test()
    {
        print("RAIN ON");
    }
}
