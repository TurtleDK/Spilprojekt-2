using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class CloseDoor : MonoBehaviour
{
    public float soundVolume;
    private Animation closeDoor;
    private AudioSource Audio1;
    [SerializeField] private Image BlackScreen;

    [SerializeField] private GameObject Door;

    // Start is called before the first frame update
    void Start()
    {

        closeDoor = Door.GetComponent<Animation>();
        
        Audio1 = gameObject.GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Audio1.volume = soundVolume;
            Audio1.Play();
            closeDoor.Play();
            StartCoroutine(StartNextLevel());
        }
    }

    IEnumerator StartNextLevel()
    {
        yield return new WaitForSeconds(2f);
        Color tempColor = BlackScreen.color;
        while (BlackScreen.color.a != 1.0f)
        {
            yield return new WaitForSeconds(0.01f);
            tempColor.a += 0.01f;
            BlackScreen.color = tempColor;
        }
        PhotonNetwork.LoadLevel(3);
    }
}
  