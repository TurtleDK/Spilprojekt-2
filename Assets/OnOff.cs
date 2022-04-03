using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class OnOff : MonoBehaviour
{
    private MouseLook _mouseLook;


    private void Start()
    {
        _mouseLook = FindObjectOfType<MouseLook>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            
            if (!gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            
            gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
            
            _mouseLook.settingOpened = gameObject.transform.GetChild(0).gameObject.activeInHierarchy;
        }
    }
}
