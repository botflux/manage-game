using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ManageGame;

public class GameManager : MonoBehaviour
{
    private NoiseMapSettings settings;
    private float[,] noiseMap;

    private void Start ()
    {
        Debug.Log("Start!");

        settings = new NoiseMapSettings(30, 30, 2f, 0.5f, 2, new Vector2(0, 0), 10, Random.Range(int.MinValue, int.MaxValue));
        noiseMap = NoiseMap.GenerateMap(settings.MapWidth, settings.MapHeight, settings.Scale, settings.Seed, settings.Octaves, settings.Persistance, settings.Lacunarity, settings.Offset);
    }
    
    private void OnDrawGizmos ()
    {
        if (noiseMap != null)
        {
            Vector3 bottomLeft = transform.position - (Vector3.right * ((float)settings.MapWidth / 2f)) - (Vector3.forward * ((float)settings.MapHeight / 2f));

            // debug la map

            for (int i = 0; i < settings.MapWidth; i++)
            {
                for (int j = 0; j < settings.MapHeight; j++)
                {
                    // set the cellule color
                    Gizmos.color = Color.Lerp(Color.white, Color.black, noiseMap[i,j]);

                    Vector3 position = bottomLeft + Vector3.right * i + Vector3.forward * j;

                    Gizmos.DrawCube(position, Vector3.one * 0.9f);
                }
            }
        }
    }

    private struct NoiseMapSettings
    {
        private int mapWidth;
        private int mapHeight;
        private float persistance;  // 2
        private float lacunarity;   // 0.5
        private int octaves;        // 2
        private Vector2 offset;     // 0 0
        private float scale;        // 10
        private int seed;

        public NoiseMapSettings (int mapWidth, int mapHeight, float persistance, float lacunarity, int octaves, Vector2 offset, float scale, int seed)
        {
            this.mapHeight = mapHeight;
            this.mapWidth = mapWidth;
            this.persistance = persistance;
            this.lacunarity = lacunarity;
            this.octaves = octaves;
            this.offset = offset;
            this.scale = scale;
            this.seed = seed;
        }

        public float Persistance
        {
            get
            {
                return persistance;
            }

            set
            {
                persistance = value;
            }
        }

        public float Lacunarity
        {
            get
            {
                return lacunarity;
            }

            set
            {
                lacunarity = value;
            }
        }

        public int Octaves
        {
            get
            {
                return octaves;
            }

            set
            {
                octaves = value;
            }
        }

        public Vector2 Offset
        {
            get
            {
                return offset;
            }

            set
            {
                offset = value;
            }
        }

        public float Scale
        {
            get
            {
                return scale;
            }

            set
            {
                scale = value;
            }
        }

        public int Seed
        {
            get
            {
                return seed;
            }

            set
            {
                seed = value;
            }
        }

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
    } 
}
