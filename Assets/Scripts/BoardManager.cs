using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private Tilemap m_tilemap;
    [SerializeField] private Tile[] groundTiles;
    [SerializeField] private Tile[] wallTiles;
    
    void Start()
    {
        m_tilemap = GetComponentInChildren<Tilemap>();
        int wallIndex = Random.Range(0, 2);

        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                Tile tile;

                // Wall tiles when x,y == 0 || -1
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                {
                    tile = wallTiles[wallIndex];
                }
                else
                // Inner tiles
                {
                    tile = groundTiles[Random.Range(0, groundTiles.Length)];
                }

                m_tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }

    void Update()
    {
        
    }
}
