using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerControl : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;
    public TileBase selectedTile;
    public TileBase defaultTile;
    public bool tileSelected;
    public Vector3Int currentlySelectedTile;
    bool firstSelected = false;
    public TileBase[] temp;
    bool hasTileSelected = false;
    GameObject buildableTile;
    public Vector3Int tilePos;





    //Awake means it starts before everything else, even before "Start"-methods
    private void Awake()
    {
        temp = tilemap.GetTilesBlock(tilemap.cellBounds);
    }

    //Every frame
    void Update()
    {
        //Check every frame for mouse input
        OnMouseDown();

        if (!GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isInMenu)
        {
            if (Input.GetKeyDown(KeyCode.B) && hasTileSelected)
            {
                GetSelectedTile().GetComponent<BuildableTile>().BuildingTower();
            }
            if (Input.GetKeyDown(KeyCode.S) && hasTileSelected)
            {
                GetSelectedTile().GetComponent<BuildableTile>().SellingTower();
            }
        }
    }

    //set the current tile; useful for placing towers etc.
    void SetTile(Vector3Int tilePos)
    {
        
        if (tilemap.GetTile(tilePos) && !GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isInMenu)
        {
            tileSelected = true;
            if (tilemap.GetTile(tilePos) && !firstSelected || currentlySelectedTile == tilePos)
            {
                firstSelected = true;
                currentlySelectedTile = tilePos;
                tilemap.SetTile(tilePos, selectedTile);
            }
            else if (currentlySelectedTile != tilePos)
            {
                tilemap.SetTile(currentlySelectedTile, defaultTile);
                tilemap.SetTile(tilePos, selectedTile);
                currentlySelectedTile = tilePos;
            }
            
        }
    }

    //gets the poisition of the tile
    Vector3Int GetTilePos()
    {
        return tilemap.origin;
    }


    private void OnMouseDown()
    {
        //when Mouse-Left click
        if (Input.GetMouseButtonDown(0))
        {
            //get position of mouse
            Vector3 pos = Input.mousePosition;
            //get position of tile relative to screen
            tilePos = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(pos));

            SetTile(tilePos);

            //get the mousePos relative to screen to world point
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //store mousePos in a vector2 variable
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            //A Raycast essentially “draws” a line between two points in the game world, 
            //and detects any physics bodies that are hit along the way. You can then use 
            //this information to determine what was hit by the Raycast and act accordingly
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            
            //perform task, if it hits something which has a collider
            if (hit.collider != null)
            {
                //get buildable tile on mouse-click
                SelectedTile(hit);
                hasTileSelected = true;
            }
            else
            {
                UnselectTile();
            }
        }
    }

    //method to deselect current tile; so if you click somewhere else than a buildable tile, you unselect current tile
    //disable also building function for the last buildable tile you've clicked after you clicked on a non-buildable tile
    private void UnselectTile()
    {
        tilemap.SetTile(currentlySelectedTile, defaultTile);
        hasTileSelected = false;
    }

    //set the gameObject to the hit marker from raycast
    void SelectedTile(RaycastHit2D hit)
    {
        buildableTile = hit.transform.gameObject;
    }


    //just returns the game object
    GameObject GetSelectedTile()
    {
        return buildableTile;
    }
}
