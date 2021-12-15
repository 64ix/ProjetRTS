using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "ScriptableObjects/BuildingData", order = 1)]
public class BuildingData : ScriptableObject
{
    public new string buildingName;
    public int maxLevel;
    public int minLevel;
    public int[] initialCosts;
    public float levelMultiplier;
    public int initialProduction;
}

