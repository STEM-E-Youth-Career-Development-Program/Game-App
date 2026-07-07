using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public float delayBeforeSceneLoad = 3f;

    public CameraFollow cameraFollow;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            VehicleController vehicle = collision.transform.root.GetComponent<VehicleController>();

            if (vehicle != null)
            {
                vehicle.controlsEnabled = false;
            }

            if (cameraFollow != null)
            {
                cameraFollow.enabled = false;
            }

            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSecondsRealtime(delayBeforeSceneLoad);

        Time.timeScale = 1f; // Reset in case it was frozen

        SceneManager.LoadScene("WinLossScreen");
    }
}
