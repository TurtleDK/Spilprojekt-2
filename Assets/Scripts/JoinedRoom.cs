using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class JoinedRoom : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject Hus1;
    [SerializeField] private GameObject Hus2;
    private GameObject player;
    private bool playerSpawned = false;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint1.transform.position,
                spawnPoint1.transform.rotation);
            player.transform.parent = Hus1.transform;
            player.transform.GetChild(1).gameObject.SetActive(true);
            playerSpawned = true;
        }
        else
        {
            player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint2.transform.position,
                spawnPoint2.transform.rotation);
            player.transform.parent = Hus2.transform;
            player.transform.GetChild(1).gameObject.SetActive(true);
            playerSpawned = true;
        }
    }
    
    
}



/*
if (!playerSpawned)
{
    for (int i = 0; i < Hus1.transform.childCount; i++)
    {
        if (Hus1.transform.GetChild(i).name.Contains(playerPrefab.name))
        {
            player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            player.transform.parent = Hus2.transform;
            player.transform.GetChild(1).gameObject.SetActive(true);
            playerSpawned = true;
        }
    }
    if (!playerSpawned)
    {
        player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
        player.transform.parent = Hus1.transform;
        player.transform.GetChild(1).gameObject.SetActive(true);
        playerSpawned = true;
    }
}

if (!playerSpawned)
{
    for (int i = 0; i < Hus2.transform.childCount; i++)
    {
        if (Hus2.transform.GetChild(i).name.Contains(playerPrefab.name))
        {
            player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            player.transform.parent = Hus1.transform;
            player.transform.GetChild(1).gameObject.SetActive(true);
            playerSpawned = true;
        }
    }
    if (!playerSpawned)
    {
        player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
        player.transform.parent = Hus2.transform;
        player.transform.GetChild(1).gameObject.SetActive(true);
        playerSpawned = true;
    }
}
}
*/ 

