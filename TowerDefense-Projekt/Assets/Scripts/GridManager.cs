using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public GameObject buildableTile;
    public Tilemap tileMap;
    public List<Vector3> availablePlaces;

    //Start the level with generating its Buildable Tiles first
    void Start()
    {
        GenerateBuidableTiles();
    }


    //Generate a list of tiles; in this list there are all buildable tiles generated automatically
    void GenerateBuidableTiles()
    {
        //create a list where all tiles are stored
        availablePlaces = new List<Vector3>();

        
        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
        {
            for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
            {

                Vector3Int localPlace = (new Vector3Int(n, p, (int)tileMap.transform.position.y));
                Vector3 place = tileMap.CellToWorld(localPlace);

                //makes all of the tiles move a bit up and to the right; this centers every buildable tile object to the grid
                place = place + new Vector3(0.5f, 0.5f);

                if (tileMap.HasTile(localPlace))
                {
                    //Tile at "place"
                    availablePlaces.Add(place);
                    Instantiate(buildableTile, place, Quaternion.identity);
                }
                else
                {
                    //No tile at "place"
                }
            }
        }
    }


}
