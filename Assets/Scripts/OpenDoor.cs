using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviourPun
{
    GameObject Door;
    GameObject Door1;
    private Animation openDoor;
    private Animation openDoor1;
    private TMPro.TMP_Text Texts;
    private TMPro.TMP_Text Texts1;
    private GameObject Text;
    private GameObject Text1;
    private AudioSource Audio1;
    private AudioSource Audio2;
    private RandomColor _randomColor;

    public float soundVolume = 0.5f;
    
    private bool Ran = false;
    private string textField;
    
    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.Find("Text1");
        Texts = Text.GetComponent<TextMeshPro>();

        textField = Texts.text;
        
        Text1 = GameObject.Find("Text2");
        Texts1 = Text1.GetComponent<TextMeshPro>();
        
        Door = GameObject.Find("Door");
        Door1 = GameObject.Find("Door1");
        
        openDoor = Door.GetComponent<Animation>();
        openDoor1 = Door1.GetComponent<Animation>();

        Audio1 = Door.GetComponent<AudioSource>();
        Audio2 = Door1.GetComponent<AudioSource>();

        _randomColor = FindObjectOfType<RandomColor>();
    }

    [PunRPC]
    void UpdateText(string a)
    {
        Texts1.text = a;
        Texts.text = a;
    }

    private float waitedTime;
    
    void Update()
    {
        if (textField != Texts.text)
        {
            textField = Texts.text;
            photonView.RPC("UpdateText", RpcTarget.OthersBuffered, textField);
        }

        waitedTime += Time.deltaTime;
        
        if (Texts.text == _randomColor.Code && waitedTime > 1f && Ran == false)
        {
            print("I opened it");
            print(Texts.text);
            openDoor.Play("WallUp");
            openDoor1.Play("WallUp");

            Audio1.volume = soundVolume;
            Audio1.Play();
            Audio2.volume = soundVolume;
            Audio2.Play();
            
            Ran = true;
        }
    }
}
