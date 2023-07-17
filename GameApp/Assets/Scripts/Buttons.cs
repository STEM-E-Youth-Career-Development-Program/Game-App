using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void click(string sceneName)
    {
        Debug.Log("hey");
        SceneManager.LoadScene(sceneName);
    }
}
