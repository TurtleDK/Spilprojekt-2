using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RandomColor : MonoBehaviour
{
    // Start is called before the first frame update

    private Color[] Colors = {new Color(255, 255, 0), new Color(255, 0, 0), new Color(0, 0, 255), new Color(0, 51,160)};

    [SerializeField] private TextMeshPro Color1;
    [SerializeField] private TextMeshPro Color2;
    [SerializeField] private TextMeshPro Color3;

    private int RandomTal;
    private Color32 Color;

    [SerializeField] TextMeshPro ThisColor;
    
    void Start()
    {
        TextMeshPro ThisColor = GetComponent<TextMeshPro>();
        Color1.GetComponent<TextMeshPro>();
        Color2.GetComponent<TextMeshPro>();
        Color3.GetComponent<TextMeshPro>();
        ColorPick();
    }
    void ColorPick()
    {
        RandomTal= Random.Range(0, 4);
        Debug.Log(RandomTal);
        Color = Colors[RandomTal];

        if (Color == Color1.color || Color == Color2.color|| Color == Color3.color)
        {
            ColorPick();
        }
        else
        {
             ThisColor.color = Color;
        }
    }
}
