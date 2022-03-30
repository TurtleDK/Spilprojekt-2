using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class Click1 : MonoBehaviour
{

    GameObject player;
    private Transform pos;
    private GameObject Text;
    private TMPro.TMP_Text Texts;
    private string PreviousText;
    [SerializeField] private string Tal;
    
    private GameObject Text1;
    private TMPro.TMP_Text Texts1;

    private Outline Outline;
    
    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.Find("Text1");
        player = GameObject.Find("FirstPersonPlayer(Clone)");
        pos = player.GetComponent<Transform>();
        Texts = Text.GetComponent<TextMeshPro>();
        
        Text1 = GameObject.Find("Text2");
        Texts1 = Text1.GetComponent<TextMeshPro>();

        Outline = gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (Input.GetKeyDown(KeyCode.E) && Outline.enabled == true)
        {
            PreviousText = Texts.text;
            Texts.text = PreviousText + Tal;
            
            PreviousText = Texts1.text;
            Texts1.text = PreviousText + Tal;
        }
    }
}
