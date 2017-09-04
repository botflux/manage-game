using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ManageGame;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private NoiseMapSettings settings;

    public bool showGizmosGrid = false;

    private Grid grid;

    #region Components references
    private GameObjectManager gameObjectManager;
    #endregion

    private void Awake ()
    {
        gameObjectManager = GetComponent<GameObjectManager>();
    }

    private void Start ()
    {
        Debug.Log("Start Game!");
        GenerateMap();
    }
    
    private void GenerateMap ()
    {
        float[,] noiseMap = NoiseMap.GenerateMap(settings.MapWidth, settings.MapHeight, settings.Scale, settings.Seed, settings.Octaves, settings.Persistance, settings.Lacunarity, settings.Offset);
        grid = new Grid(settings.MapWidth, settings.MapHeight, noiseMap);
        gameObjectManager.InstantiateMap(grid);
    }

    private void OnDrawGizmos ()
    {
        if (grid != null && showGizmosGrid)
        {
            Vector3 bottomLeft = transform.position - (Vector3.right * ((float)settings.MapWidth / 2f)) - (Vector3.forward * ((float)settings.MapHeight / 2f));
            
            for (int i = 0; i < settings.MapWidth; i++)
            {
                for (int j = 0; j < settings.MapHeight; j++)
                {
                    // set cellule color
                    Gizmos.color = Color.Lerp(Color.white, Color.black, grid.GetCellule(i,j).Height);
                    // set cellule position
                    Vector3 position = bottomLeft + Vector3.right * i + Vector3.forward * j;
                    // draw hit
                    Gizmos.DrawCube(position, Vector3.one * 0.9f);
                }
            }
        }
    }

    [System.Serializable]
    private struct NoiseMapSettings
    {
        [SerializeField]
        private int mapWidth;
        [SerializeField]
        private int mapHeight;
        [SerializeField]
        private float persistance;  // 2
        [SerializeField]
        private float lacunarity;   // 0.5
        [SerializeField]
        private int octaves;        // 2
        [SerializeField]
        private Vector2 offset;     // 0 0
        [SerializeField]
        private float scale;        // 10
        [SerializeField]
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
