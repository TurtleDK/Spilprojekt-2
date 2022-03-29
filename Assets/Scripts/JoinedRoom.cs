using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class JoinedRoom : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject Hus1;
    [SerializeField] private GameObject Hus2;
    private GameObject player;
    private bool playerSpawned = false;
    
    void Start()
    {
        if (!playerSpawned)
        {
            for (int i = 0; i < Hus1.transform.childCount; i++)
            {
                if (Hus1.transform.GetChild(i).name == "FirstPersonPlayer(Clone)")
                {
                    player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    player.transform.parent = Hus2.transform;
                    player.transform.GetChild(1).gameObject.SetActive(true);
                    playerSpawned = true;
                }
            }

            if (!playerSpawned)
            {
                player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.transform.position, spawnPoint.transform.rotation);
                player.transform.parent = Hus1.transform;
                player.transform.GetChild(1).gameObject.SetActive(true);
                playerSpawned = true;
            }
        }

        if (!playerSpawned)
        {
            for (int i = 0; i < Hus2.transform.childCount; i++)
            {
                if (Hus2.transform.GetChild(i).name == "FirstPersonPlayer(Clone)")
                {
                    player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    player.transform.parent = Hus1.transform;
                    player.transform.GetChild(1).gameObject.SetActive(true);
                    playerSpawned = true;
                }
            }
            if (!playerSpawned)
            {
                player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.transform.position, spawnPoint.transform.rotation);
                player.transform.parent = Hus2.transform;
                player.transform.GetChild(1).gameObject.SetActive(true);
                playerSpawned = true;
            }
        }
        
    }
}
