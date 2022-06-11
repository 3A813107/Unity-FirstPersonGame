using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Intro_02 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level_02");
    }
}
