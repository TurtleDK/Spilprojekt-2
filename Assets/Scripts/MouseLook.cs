using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    private Transform lookingAt;
    [SerializeField] private GameObject Crosshair;
    [SerializeField] LayerMask Mask;
    [SerializeField] private GameObject SettingsPanel;
    private Slider sensSlider;

    public bool settingOpened = false;
    
    public RaycastHit hit;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Crosshair = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        SettingsPanel = GameObject.Find("Settings");
        
        /*
        for (int i = 0; i < SettingsPanel.transform.GetChild(0).childCount; i++)
        {
            if (SettingsPanel.transform.GetChild(0).GetChild(i).name == "Sensitivity")
            {
                sensSlider = SettingsPanel.transform.GetChild(0).GetChild(i).gameObject.GetComponent<Slider>();
                break;
            }
        }
        */
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (settingOpened == false)
        {
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90, 90);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        if (Physics.Raycast(ray, out hit, 7.5f, Mask))
        {
            lookingAt = hit.transform;
            lookingAt.GetComponent<Outline>().enabled = true;
            Crosshair.transform.GetChild(1).GetComponent<TMP_Text>().text = lookingAt.name;
            Crosshair.SetActive(true);
        }
        else if (hit.transform != lookingAt)
        {
            lookingAt.GetComponent<Outline>().enabled = false;
            Crosshair.SetActive(false);
        }
    }
}
