using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    GameObject Door;
    GameObject Door1;
    private Animation openDoor;
    private Animation openDoor1;
    private TMPro.TMP_Text Texts;
    private GameObject Text;
    private AudioSource Audio1;
    private AudioSource Audio2;

    private bool Ran = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.Find("Text1");
        Texts = Text.GetComponent<TextMeshPro>();
        
        Door = GameObject.Find("Door");
        Door1 = GameObject.Find("Door1");
        
        openDoor = Door.GetComponent<Animation>();
        openDoor1 = Door1.GetComponent<Animation>();

        Audio1 = Door.GetComponent<AudioSource>();
        Audio2 = Door1.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Texts.text == "1432" && Ran == false)
        {
            openDoor.Play("WallUp");
            openDoor1.Play("WallUp");

            Audio1.Play();
            Audio2.Play();
            
            Ran = true;
        }
    }
}
