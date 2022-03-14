using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
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
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Crosshair = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    
    void FixedUpdate()
    {
        Debug.DrawRay(transform.TransformDirection(Vector3.forward), transform.forward, Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, Mask))
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
