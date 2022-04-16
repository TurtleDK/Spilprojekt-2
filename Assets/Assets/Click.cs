using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class Click : MonoBehaviour
{

    GameObject player;
    private Transform pos;
    private GameObject Text;
    private TMPro.TMP_Text Texts;
    private string PreviousText;
    
    private GameObject Text1;
    private TMPro.TMP_Text Texts1;
    
    private Outline Outline;
    private AudioSource Audio1;
    public float soundVolume;
    
    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.Find("Text1");
        player = GameObject.Find("Player1");
        pos = player.GetComponent<Transform>();
        Texts = Text.GetComponent<TextMeshPro>();
        
        Text1 = GameObject.Find("Text2");
        Texts1 = Text1.GetComponent<TextMeshPro>();
        
        Outline = gameObject.GetComponent<Outline>();
        Audio1 = gameObject.GetComponent<AudioSource>();
        
        Audio1.volume = soundVolume;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        PreviousText = Texts.text;
        if (PreviousText.Length > 4)
        {
            Texts.text = "";
            Texts1.text = "";
        }

        if (Input.GetKeyDown(KeyCode.E) && Outline.enabled == true)
        {
            Audio1.Play();
            Texts.text = "";
            Texts1.text = "";
        }
    }
}
