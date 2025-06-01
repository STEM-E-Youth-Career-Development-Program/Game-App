using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void click(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
