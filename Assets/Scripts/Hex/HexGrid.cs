using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public static HexGrid instance;
    public HexCell HexCellPrefab;
    public int height = 100;
    public int width = 100;
    public HexCell[][] Map;

    private void Awake()
    {
        instance = this;
        Map = new HexCell[height][];
        for (int i = 0; i < height; i++)
        {
            Map[i] = new HexCell[width];
        }
    }
    void Start()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, y);
            }
        }
    }
    void CreateCell(int x, int y)
    {
        Vector2 position = new Vector2((x + y * 0.5f - y / 2) * (HexMetrics.innerRadius * 2f), y * (HexMetrics.outerRadius * 1.5f));
        HexCell cell = Map[y][x] = Instantiate<HexCell>(HexCellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition= position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, y);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
