using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellule
{
    private int locationX;
    private int locationY;
    private float height;

    public int LocationX
    {
        get
        {
            return locationX;
        }

        set
        {
            locationX = value;
        }
    }

    public int LocationY
    {
        get
        {
            return locationY;
        }

        set
        {
            locationY = value;
        }
    }

    public float Height
    {
        get
        {
            return height;
        }

        set
        {
            height = value;
        }
    }

    public Cellule (int locationX, int locationY, float height)
    {
        this.LocationX = locationX;
        this.LocationY = locationY;
        this.Height = height;
    }
}
