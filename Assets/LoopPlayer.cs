using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LoopPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Volume volumeSettings;
    private Fog fog;
    private float prevDist;

    // Start is called before the first frame update
    void Start()
    {
        volumeSettings.profile.TryGet(out fog);
        fog.meanFreePath.value = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.localPosition, new Vector3(0, 0, 0)) >= 20)
        {
            fog.meanFreePath.value = 80/Vector3.Distance(Player.transform.localPosition, new Vector3(0, 0, 0))*25-50;
            
        }
        

        if (fog.meanFreePath.value <= 10)
        {
            Player.transform.localPosition = new Vector3(Player.transform.localPosition.x * -1,
                Player.transform.localPosition.y, Player.transform.localPosition.z * -1);
        }
    }
}
