using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class StartPuzzle2 : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject playerGameObject;
    private GameObject _spawnedPlayer;
    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform spawn2;
    [SerializeField] private Image blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            wall.SetActive(true);
            _spawnedPlayer = PhotonNetwork.InstantiateRoomObject(playerGameObject.name, spawn1.position, spawn1.rotation);
            _spawnedPlayer.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            _spawnedPlayer = PhotonNetwork.InstantiateRoomObject(playerGameObject.name, spawn2.position, spawn2.rotation);
            _spawnedPlayer.transform.GetChild(1).gameObject.SetActive(true);
        }

        StartCoroutine(RemoveBlackScreen());
    }

    IEnumerator RemoveBlackScreen()
    {
        yield return new WaitForSeconds(2f);
        Color tempColor = blackScreen.color;
        while (blackScreen.color.a != 0)
        {
            yield return new WaitForSeconds(0.01f);
            tempColor.a -= 0.01f;
            blackScreen.color = tempColor;
        }
    }
}
