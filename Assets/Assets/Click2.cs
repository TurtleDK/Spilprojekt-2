using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class Click2 : MonoBehaviour
{

    GameObject player;
    private Transform pos;
    private GameObject Text;
    private TMPro.TMP_Text Texts;
    private string PreviousText;
    
    private GameObject Text1;
    private TMPro.TMP_Text Texts1;
    
    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.Find("Text1");
        player = GameObject.Find("FirstPersonPlayer(Clone)");
        pos = player.GetComponent<Transform>();
        Texts = Text.GetComponent<TextMeshPro>();
        
        Text1 = GameObject.Find("Text2");
        Texts1 = Text1.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (Input.GetKeyDown(KeyCode.E) && distance < 4)
        {
            PreviousText = Texts.text;
            Texts.text = PreviousText + "3";
            
            PreviousText = Texts1.text;
            Texts1.text = PreviousText + "3";
        }
    }
}
