using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class RandomColor : MonoBehaviourPun
{
    // Start is called before the first frame update

    private List<Color> Colors = new List<Color>(){new Color(255, 255, 0), new Color(255, 0, 0), new Color(0, 0, 255), new Color(0, 255,255)};
    private List<int> Codes = new List<int>(){1, 2, 3, 4};

    [SerializeField] private TextMeshPro[] ColorBricks;
    [SerializeField] private Material[] StickyNotes; 
    [SerializeField] public string Code;

    private int numberCode;
    private int RandomTal;
    private Color Color;
    
    [PunRPC]
    void ShareCode(string a)
    {
        Code = a;
    }

    void Start()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                numberCode = Random.Range(0, Codes.Count);
                RandomTal = Random.Range(0, Colors.Count);  

                Code += Codes[numberCode];
                Color = Colors[RandomTal];

                ColorBricks[i].GetComponent<TMP_Text>().color = Color;
                StickyNotes[Codes[numberCode]-1].color = Color;
            
                Colors.RemoveAt(RandomTal);
                Codes.RemoveAt(numberCode);
            }
            
            photonView.RPC("ShareCode", RpcTarget.OthersBuffered, Code);
        }
    }
    
    
}
