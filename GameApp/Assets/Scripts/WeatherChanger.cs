using UnityEngine;
using UnityEngine.Events;

public class WeatherChanger : MonoBehaviour
{
    public UnityEvent slip, regain;

    public VehicleController vCtrl;
    // Update is called once per frame
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            slip.Invoke();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            regain.Invoke();
        }
    }

    public void Test1()
    {
        print("RAIN ON");
        vCtrl.curTCS *= .5f;
    }

    public void Test2()
    {
        print("RAIN OFF");
        vCtrl.curTCS *= 2;
    }
}
