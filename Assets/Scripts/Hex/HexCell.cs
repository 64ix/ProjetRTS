using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    //Coordinates
    public HexCoordinates coordinates;

    public Village village = null;

    SpriteRenderer spriteRenderer;
    public bool isVillage
    {
        get
        {
            return village != null;
        }
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateVillage(Player player, GameObject topBar)
    {
        village = new Village(this, player,topBar);
        Debug.Log("New village at : " + coordinates.ToString() );
        spriteRenderer.color = Color.blue;
    }
}
public static class HexMetrics
{
    public const float outerRadius = 0.525f;
    public const float innerRadius = outerRadius * 0.866025404f;

}



