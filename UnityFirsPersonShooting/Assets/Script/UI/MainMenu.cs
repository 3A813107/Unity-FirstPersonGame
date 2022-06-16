using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OpenLevel_01()
    {
        SceneManager.LoadScene("Intro_01");
    }
    public void OpenLevel_02()
    {
        SceneManager.LoadScene("Intro_02");
    }
    public void OpenLevel_03()
    {
        SceneManager.LoadScene("Intro_03");
    }
    public void OpenLevel_04()
    {
        SceneManager.LoadScene("Intro_04");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
