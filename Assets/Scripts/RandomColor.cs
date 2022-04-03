using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Random = UnityEngine.Random;

public class RandomColor : MonoBehaviourPun
{
    // Start is called before the first frame update

    private List<Color> Colors = new List<Color>(){new Color(255, 255, 0), new Color(255, 0, 0), new Color(0, 0, 255), new Color(0, 255,255)};
    private List<int> Codes = new List<int>(){1, 2, 3, 4};

    [SerializeField] private TextMeshPro[] ColorBricks;
    [SerializeField] private Material[] StickyNotes; 
    [SerializeField] public string Code;
    private List<Color> ColorsList = new List<Color>();

    private int numberCode;
    private int RandomTal;
    private int CodeInt;
    private Color Color;

    [PunRPC]
    void ShareCode(string a, List<Color> List)
    {
        Code = a;
        ColorsList = List;
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
                
                ColorsList.Add(Color);
            
                Colors.RemoveAt(RandomTal);
                Codes.RemoveAt(numberCode);
            }
            
            photonView.RPC("ShareCode", RpcTarget.OthersBuffered, Code, ColorsList);
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                int.TryParse(Code[i].ToString(), out CodeInt);
                StickyNotes[CodeInt].color = ColorsList[i];
            }
        }
    }
    
    
}
