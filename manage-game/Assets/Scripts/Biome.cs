using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Biome
{
    [SerializeField]
    private string name;
    [SerializeField]
    private Color color;
    [SerializeField]
    private float height;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public Color Color
    {
        get
        {
            return color;
        }

        set
        {
            color = value;
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

    public Biome (string name, Color color, float height)
    {
        this.Name = name;
        this.Color = color;
        this.Height = height;
    }
}