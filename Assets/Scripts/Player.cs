using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Village> villages = new List<Village>();
    public Village activeVillage;
    public string Name;

    void Start()
    {
        name = "Sika";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
