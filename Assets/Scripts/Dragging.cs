using System;
using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.PlayerLoop;


public class Dragging : MonoBehaviour

{
    private Vector3 mOffset;
    private float mZCoord;
    private Rigidbody rb;
    private bool isDragging = false;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        //mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        isDragging = true;
        rb.useGravity = false;
    }

    private void OnMouseUp()
    {
        rb.constraints = RigidbodyConstraints.None;
        isDragging = false;
        rb.useGravity = true;
        //gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void FixedUpdate()
    {
        if (isDragging && rb.position != GetMouseAsWorldPoint() + mOffset)
        {
            rb.velocity =((GetMouseAsWorldPoint() + mOffset)-rb.position).normalized*10;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void OnMouseDrag()
    {
        //gameObject.GetComponent<Rigidbody>().mo
        //gameObject.GetComponent<Rigidbody>().MovePosition(GetMouseAsWorldPoint() + mOffset);
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

}