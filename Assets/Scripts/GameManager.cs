using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<BuildingData> buildingsTemplate;
    public List<Village> allVillages;
    public float ProdTime = 10f;

    private void Awake()
    {
        Instance = this;
        allVillages = new List<Village>();
    }
    void Start()
    {
        StartCoroutine(ProductionTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ProductionTimer()
    {
        while (true)
        {
        yield return new WaitForSeconds(ProdTime);
        ProductionAll();
        }
    }

    private void ProductionAll()
    {
        //Debug.Log("Prod en cours");
        foreach (var item in allVillages)
        {
            item.Production();
        }
    }
}
