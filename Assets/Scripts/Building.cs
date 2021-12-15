using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building 
{

    public BuildingData data;

    public Building(BuildingData buildingData)
    {
        data = buildingData;
        CurrentLevel = data.minLevel;
    }
    public int CurrentLevel { get; private set; }


    public int[] Cost
    {
        get
        {
            int[] final = new int[3];
            int count = 0;
            foreach (var init in data.initialCosts)
            {
                final[count] = Mathf.RoundToInt(init * Mathf.Pow(data.levelMultiplier, CurrentLevel + 1 - data.minLevel));
                count++;
            }
            return final;

        }
    }


    public void Upgrade()
    {
        CurrentLevel++;
    }
}
