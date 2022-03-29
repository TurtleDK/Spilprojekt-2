using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

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
        if (!playerSpawned)
        {
            for (int i = 0; i < Hus2.transform.childCount; i++)
            {
                if (Hus1.transform.GetChild(i).name.Contains(playerPrefab.name))
                {
                    player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
                    player.transform.name = "FirstPersonPlayerHus1";
                    player.transform.GetChild(1).gameObject.SetActive(true);
                    playerSpawned = true;
                }
            }
            if (!playerSpawned)
            {
                player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
                player.transform.name = "FirstPersonPlayerHus2";
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
                    player.transform.name = "FirstPersonPlayerHus1";
                    player.transform.GetChild(1).gameObject.SetActive(true);
                    playerSpawned = true;
                }
            }
            if (!playerSpawned)
            {
                player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
                player.transform.name = "FirstPersonPlayerHus2";
                player.transform.GetChild(1).gameObject.SetActive(true);
                playerSpawned = true;
            }
        }
        
    }
}
