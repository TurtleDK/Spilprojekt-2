using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWall : MonoBehaviour
{
    [SerializeField] private GameObject Wall;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Wall.SetActive(true);
    }
}
