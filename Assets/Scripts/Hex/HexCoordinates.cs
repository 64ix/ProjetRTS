using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
    public HexCoordinates(int q, int r)
    {
        this.q = q;
        this.r = r;
    }
    [SerializeField]
    private int q, r;

    public int Q
    {
        get
        {
            return q;
        }
    }

    public int R
    {
        get
        {
            return r;
        }
    }
    public int S
    {
        get
        {
            return -Q - R;
        }
    }

    public static HexCoordinates FromOffsetCoordinates(int x, int y)
    {
        return new HexCoordinates(x - y / 2, y);
    }
    public static HexCoordinates InTab(HexCoordinates coordinates)
    {
        return new HexCoordinates(coordinates.Q + (int)Mathf.Floor(coordinates.R / 2),coordinates.R);
    }

    public static HexCoordinates FromPosition(Vector2 position)
    {
        float q = position.x / (HexMetrics.innerRadius * 2f);
        float r = -q;
        float offset = position.y / (HexMetrics.outerRadius * 3f);
        q -= offset;
        r -= offset;
        int iQ = Mathf.RoundToInt(q);
        int iR = Mathf.RoundToInt(r);
        int iS = Mathf.RoundToInt(-q - r);
        if (iQ + iR + iS != 0)
        {
            float dX = Mathf.Abs(q - iQ);
            float dY = Mathf.Abs(r - iR);
            float dZ = Mathf.Abs(-q - r - iS);

            if (dX > dY && dX > dZ)
            {
                iQ = -iR - iS;
            }
            else if (dZ > dY)
            {
                iS = -iQ - iR;
            }
        }

        return new HexCoordinates(iQ, iS);
    }

    public override string ToString()
    {
        return "(" +
            Q.ToString() + ", " + R.ToString() + ", " + S.ToString() + ")";
    }

    public string ToStringOnSeparateLines()
    {
        return Q.ToString() + "\n" + R.ToString() + "\n" + S.ToString();
    }
}

