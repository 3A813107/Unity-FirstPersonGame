using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100;
    public Transform playerBody;
    public Transform arms;
    float xRotation=0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(!GameManager.isPause)
        {
            float mouseX =  Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY =  Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation,-90f,57.5f);

            arms.localRotation = Quaternion.Euler(xRotation,0f,0f);

            playerBody.Rotate(Vector3.up*mouseX);
        }

    }
}
