using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class Sensitivity : MonoBehaviour
{
    private MouseLook _mouseLook;
    private OpenDoor _openDoor;
    private CloseDoor _closeDoor;

    [SerializeField] private GameObject volumeSlider;
    [SerializeField] private GameObject sensSlider;

    private void Start()
    {
        _mouseLook = FindObjectOfType<MouseLook>();
        _openDoor = FindObjectOfType<OpenDoor>();
        _closeDoor = FindObjectOfType<CloseDoor>();
    }

    public void ApplySettings()
    {
        _mouseLook.mouseSensitivity = sensSlider.GetComponent<Slider>().value;
        _openDoor.soundVolume = volumeSlider.GetComponent<Slider>().value;
        _closeDoor.soundVolume = _openDoor.soundVolume;
    }
}
