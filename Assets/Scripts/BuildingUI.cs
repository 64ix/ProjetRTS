using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public Text[] texts;
    public Button button;
    public Building building;
    public Village village;



    // Update is called once per frame
    void LateUpdate()
    {
        if (button == null)
        {
            Debug.Log("Bouton cassé");
        }
        else
        {

            if (village.Ressources[0] < building.Cost[0] || village.Ressources[1] < building.Cost[1] || village.Ressources[2] < building.Cost[2])
            {
                button.interactable = false;
            }
            else if (building.CurrentLevel + 1 > building.data.maxLevel)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
    }

    public void Render()
    {
        texts[0].text = building.data.buildingName + " lvl : " + building.CurrentLevel;
        texts[2].text = building.Cost[0].ToString() + " Wood";
        texts[3].text = building.Cost[1].ToString() + " Clay";
        texts[4].text = building.Cost[2].ToString() + " Iron";

    }

    public void Upgrade()
    {
        if (building.CurrentLevel + 1 <= building.data.maxLevel)
        {
            if (village.Ressources[0] < building.Cost[0] || village.Ressources[1] < building.Cost[1] || village.Ressources[2] < building.Cost[2])
            {
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    village.Ressources[i] -= building.Cost[i];
                }
                building.Upgrade();
                Render();
                village.RefreshGUI();
            }
        }
    }

    internal void Init(Building _building, Village _village)
    {
        building = _building;
        village = _village;
        button = this.GetComponentInChildren<Button>();
        texts = this.GetComponentsInChildren<Text>();
        button.onClick.AddListener(Upgrade);
        Render();
    }
}
