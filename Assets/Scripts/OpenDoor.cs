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

    private bool Ran = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.Find("Text1");
        Texts = Text.GetComponent<TextMeshPro>();

        Text1 = GameObject.Find("Text2");
        Texts1 = Text1.GetComponent<TextMeshPro>();
        
        Door = GameObject.Find("Door");
        Door1 = GameObject.Find("Door1");
        
        openDoor = Door.GetComponent<Animation>();
        openDoor1 = Door1.GetComponent<Animation>();

        Audio1 = Door.GetComponent<AudioSource>();
        Audio2 = Door1.GetComponent<AudioSource>();
    }

    [PunRPC]
    void UpdateText(string a)
    {
        Texts1.text = a;
    }

    void Update()
    {
        photonView.RPC("UpdateText", RpcTarget.OthersBuffered, Texts.text);
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
