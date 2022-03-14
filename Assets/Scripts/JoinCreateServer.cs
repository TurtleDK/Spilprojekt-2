using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoinCreateServer : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField createInput;
    [SerializeField] TMP_InputField joinInput;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        if (PhotonNetwork.PlayerList.Length > 4)
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene(1);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(2);
    }
}
