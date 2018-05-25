using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator2D : MonoBehaviour {

    [Header("Prefabs")]//Para el editor
    [SerializeField] private Tile2D[] tilePrefabs;
    [SerializeField] private GameObject[] tankPrefabs;

    [Header("Map config")]//Para el editor
    [SerializeField] private float tileSize = 1;
    [SerializeField] private Vector2Int mapSize = new Vector2Int(10, 5);

    public void Awake()
    {
        GenerateTiles();
        GenerateTanks();
    }

    private void GenerateTiles()
    {
        for (int column = 0; column < mapSize.y; column++)
        {
            for (int row = 0; row < mapSize.x; row++)
            {
                int randomTileIndex = (int)Random.Range(0, tilePrefabs.Length);
                Tile2D newTile = Instantiate(tilePrefabs[randomTileIndex]);
                newTile.transform.position = new Vector3(
                    x: column * tileSize,
                    y: 0,
                    z: row * tileSize);
                newTile.transform.SetParent(this.transform);//Asigna el nuevo objeto al transform del MapGenerator
            }
        }
    }

    private void GenerateTanks()
    {

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
