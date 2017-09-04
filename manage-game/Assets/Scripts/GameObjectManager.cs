using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    const float DEFAULT_SIZE = 10.0f;

    public GameObject cellulePrefab;
    public Biome[] biomes;
    public GameObject[,] instantiateGrid;

    public void InstantiateMap (Grid grid)
    {
        if (cellulePrefab != null)
        {
            instantiateGrid = new GameObject[grid.MapWidth, grid.MapHeight];

            Vector3 bottomLeftCorner = transform.position - Vector3.right * ((grid.MapWidth / 2f) * cellulePrefab.transform.localScale.x * DEFAULT_SIZE) - Vector3.forward * ((grid.MapHeight / 2f) * cellulePrefab.transform.localScale.z * DEFAULT_SIZE);

            for (int i = 0; i < grid.MapWidth; i++)
            {
                for (int j = 0; j < grid.MapHeight; j++)
                {
                    Cellule cellule = grid.GetCellule(i, j);
                    Color color = GetColorFromHeight(cellule.Height);
                    Vector3 position = bottomLeftCorner + Vector3.right * (i * cellulePrefab.transform.localScale.x * DEFAULT_SIZE) + Vector3.forward * (j * cellulePrefab.transform.localScale.z * DEFAULT_SIZE);

                    instantiateGrid[i, j] = (GameObject)Instantiate(cellulePrefab, position, Quaternion.identity);
                    instantiateGrid[i, j].GetComponent<Renderer>().materials[0].color = color;
                }
            }
        }
        else
        {
            throw new System.InvalidOperationException("No cellule prefabs selected");
        }
    }

    private Color GetColorFromHeight (float height)
    {
        height = Mathf.Clamp(height, 0f, 1f);

        for (int i = 0; i < biomes.Length; i++)
        {
            if (height <= biomes[i].Height)
            {
                return biomes[i].Color;
            }
        }

        throw new System.InvalidOperationException(string.Format("Given height: {0}", height));
    }
}
