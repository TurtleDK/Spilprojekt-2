using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public float soundVolume;
    private Animation closeDoor;
    private AudioSource Audio1;

    [SerializeField] private GameObject Door;

    // Start is called before the first frame update
    void Start()
    {

        closeDoor = Door.GetComponent<Animation>();
        
        Audio1 = gameObject.GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Audio1.volume = soundVolume;
        Audio1.Play();
        //closeDoor.Play("WallDown");
        closeDoor.Play();
    }
}
  