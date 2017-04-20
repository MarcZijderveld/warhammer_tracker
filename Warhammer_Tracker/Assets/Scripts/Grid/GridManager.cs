using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    private float   tileWidth,
                    tileHeight;
    private int     gridWidth,
                    gridHeight;

    public int      webcamWidth,
                    webcamHeight;

    private Dictionary<Vector2, GridTile> tiles = new Dictionary<Vector2, GridTile>();

    private GridOverlay _overlay;

	// Update is called once per frame
	void Start () {
        _overlay = Hierarchy.GetComponentWithTag<GridOverlay>("MainCamera");
        gridWidth = _overlay.gridSizeX;
        gridHeight = _overlay.gridSizeZ;
        tileWidth = webcamWidth / gridWidth;
        tileHeight = webcamHeight / gridHeight;

        for (int i = 0; i < gridWidth; i++)
        {
            for(int j = 0; j < gridHeight; j++)
            {
                tiles.Add(new Vector2(i, j), new GridTile(i, j));
            }
        }
	}

    public Vector2 GetGridPos(Vector3 screenCord)
    {
    
         Vector2 moo =  new Vector2(Mathf.Ceil((screenCord.x - (Screen.width - webcamWidth)) / tileWidth), Mathf.Ceil(screenCord.y / tileHeight));
         return moo;
    }

    public void SetGridUnit(Vector2 gridPos, UnitGroup unit)
    {
        tiles[gridPos].unit = unit;
    }
}
