using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void Button1Click()
    {
        LoadScene("neW");
    }

    public void Button2Click()
    {
        LoadScene("SecondScene");
    }

}