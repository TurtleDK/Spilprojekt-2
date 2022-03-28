using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor1 : MonoBehaviour
{
    GameObject Door;
    private Animation closeDoor;
    private AudioSource Audio1;
    public AnimationClip[] clips;


    // Start is called before the first frame update
    void Start()
    {
        Door = GameObject.Find("Door");
        
        closeDoor = Door.GetComponent<Animation>();
        
        Audio1 = gameObject.GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        closeDoor.clip = clips[1];
        Audio1.Play();
        closeDoor.Play("WallDown");
    }
}
  