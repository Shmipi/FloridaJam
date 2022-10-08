using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonScript : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    public void StartFunction()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitFunction()
    {
        Application.Quit();
    }
}
