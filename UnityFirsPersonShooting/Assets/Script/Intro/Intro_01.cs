using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Intro_01 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level_01");
    }
}
