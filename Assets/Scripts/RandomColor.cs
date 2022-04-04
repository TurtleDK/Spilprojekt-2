using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Random = UnityEngine.Random;

public class RandomColor : MonoBehaviourPun
{
    // Start is called before the first frame update

    private List<Color32> Colors = new List<Color32>(){new Color32(164, 164, 10, 255), new Color32(164, 0, 0, 255), new Color32(0, 0, 164, 255), new Color32(10, 164,164, 255)};
    private List<int> Codes = new List<int>(){1, 2, 3, 4};

    [SerializeField] private TextMeshPro[] ColorBricks;
    [SerializeField] private Material[] StickyNotes; 
    [SerializeField] public string Code;
    private Color32[] ColorsList = new Color32[4];

    private int numberCode;
    private int RandomTal;
    private int CodeInt;
    private Color32 _color;

    [PunRPC]
    void ShareCode(string a, Vector3 color1, Vector3 color2, Vector3 color3, Vector3 color4)
    {
        Code = a;
        ColorsList[0] = new Color(color1.x, color1.y, color1.z);
        ColorsList[1] = new Color(color2.x, color2.y, color2.z);
        ColorsList[2] = new Color(color3.x, color3.y, color3.z);
        ColorsList[3] = new Color(color4.x, color4.y, color4.z);
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
                _color = Colors[RandomTal];

                ColorBricks[i].GetComponent<TMP_Text>().color = _color;
                StickyNotes[Codes[numberCode]-1].color = _color;

                ColorsList[i] = _color;
            
                Colors.RemoveAt(RandomTal);
                Codes.RemoveAt(numberCode);
            }
            
            photonView.RPC("ShareCode", RpcTarget.OthersBuffered, Code, new Vector3(ColorsList[0].r, ColorsList[0].g, ColorsList[0].b),
                new Vector3(ColorsList[1].r, ColorsList[1].g, ColorsList[1].b),
                new Vector3(ColorsList[2].r, ColorsList[2].g, ColorsList[2].b),
                new Vector3(ColorsList[3].r, ColorsList[3].g, ColorsList[3].b));
        }
        else
        {
            StartCoroutine(SetColors());
        }
    }

    IEnumerator SetColors()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 4; i++)
        {
            int.TryParse(Code[i].ToString(), out CodeInt);
            StickyNotes[CodeInt-1].color = ColorsList[i];
        }
    }
    
    
}
