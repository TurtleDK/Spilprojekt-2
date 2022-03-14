using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class JoinedRoom : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject playerPrefab;
    
    void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.transform.position, spawnPoint.transform.rotation);
        player.transform.GetChild(1).gameObject.SetActive(true);
    }
}
