using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Ending : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
