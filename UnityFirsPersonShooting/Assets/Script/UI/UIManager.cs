using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]private GameObject hudCanvas = null;
    [SerializeField]private GameObject PauseCanvas = null;

    private void Start()
    {
        SetActiveHud(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !GameManager.isPause)
        {
            SetActivePause(true);
        }
        else if(Input.GetKeyDown(KeyCode.P) && GameManager.isPause)
        {
            SetActivePause(false);
        }
    }
    public void SetActiveHud(bool state)
    {
        hudCanvas.SetActive(state);
        PauseCanvas.SetActive(!state);
    }

    public void SetActivePause(bool state)
    {
        hudCanvas.SetActive(!state);
        PauseCanvas.SetActive(state);

        if(state)
        {
            Time.timeScale = 0;
            UnLockCousor();
        }
        else
        {
            Time.timeScale = 1;
            LockCousor();
        }    


        GameManager.isPause=state;    
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void LockCousor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void UnLockCousor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
