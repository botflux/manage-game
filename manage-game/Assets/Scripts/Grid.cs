using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private Cellule[,] cellules;
    private int mapWidth;
    private int mapHeight;

    public int MapWidth
    {
        get
        {
            return mapWidth;
        }

        set
        {
            mapWidth = value;
        }
    }

    public int MapHeight
    {
        get
        {
            return mapHeight;
        }

        set
        {
            mapHeight = value;
        }
    }

    public Grid (int mapWidth, int mapHeight, float[,] noiseMap)
    {
        cellules = new Cellule[mapWidth, mapHeight];
        this.MapHeight = mapHeight;
        this.MapWidth = mapWidth;

        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                cellules[i, j] = new Cellule(i, j, noiseMap[i, j]);
            }
        }
    }

    public Cellule GetCellule (int x, int y)
    {
        if (x >= 0 && x < mapWidth && y >= 0 && y < mapHeight)
        {
            return cellules[x, y];
        }

        throw new System.IndexOutOfRangeException(string.Format("Given index: ({0},{1}); Grid size: ({2},{3})", x, y, mapWidth, mapHeight));
    }
}

