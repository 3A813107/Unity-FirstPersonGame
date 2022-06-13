using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Intro_03 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level_03");
    }
}
