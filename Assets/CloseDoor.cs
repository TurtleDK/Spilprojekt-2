using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    GameObject Door1;
    private Animation closeDoor2;
    private AudioSource Audio2;
    public AnimationClip[] clips;


    // Start is called before the first frame update
    void Start()
    {
        Door1 = GameObject.Find("Door1");
        
        closeDoor2 = Door1.GetComponent<Animation>();
        
        Audio2 = gameObject.GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        closeDoor2.clip = clips[1];
        Audio2.Play();
        closeDoor2.Play("WallDown");
    }
}
  