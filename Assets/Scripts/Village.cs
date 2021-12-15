using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Village
{
    public List<Building> buildings = new List<Building>();
    public int[] Ressources;
    public HexCell cell;
    public Player owner;
    public float productionMultiplier = 1.3f;
    public GameObject villageInfos;
    Text[] texts;
    public bool isActive = false;

    public Village(HexCell hexCell, Player player, GameObject topBar)
    {

        Ressources = new int[3] { 2000, 2000, 2000 };
        foreach (var item in GameManager.Instance.buildingsTemplate)
        {
            buildings.Add(new Building(item));
        }
        cell = hexCell;
        owner = player;
        GameManager.Instance.allVillages.Add(this);
        player.villages.Add(this);
        villageInfos = topBar;
        texts = villageInfos.transform.GetComponentsInChildren<Text>(true);
    }

    public void Production()
    {
        foreach (var item in buildings)
        {
            switch (item.data.buildingName)
            {
                case "Iron Mine":
                    Ressources[2] += (int)(item.data.initialProduction / 6 * Mathf.Pow(productionMultiplier, item.CurrentLevel));
                    break;
                case "Log Cabin":
                    Ressources[0] += (int)(item.data.initialProduction / 6 * Mathf.Pow(productionMultiplier, item.CurrentLevel));
                    break;
                case "Clay Camp":
                    Ressources[1] += (int)(item.data.initialProduction / 6 * Mathf.Pow(productionMultiplier, item.CurrentLevel));
                    break;
                default:
                    break;
            }
        }
        RefreshGUI();
    }

    public void RefreshGUI()
    {
        if (isActive)
        {
            texts[1].text = "Player : " + owner.name;
            texts[2].text = "Coords : " + cell.coordinates.ToString();
            texts[3].text = "Resources : " + Ressources[0].ToString() + " Wood, " + Ressources[1].ToString() + " Clay, " + Ressources[2].ToString() + " Iron";
        }
    }



}


