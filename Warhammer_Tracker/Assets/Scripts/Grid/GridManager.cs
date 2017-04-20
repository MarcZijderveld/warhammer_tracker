using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public int gridWidth,
                gridHeight;

    private float tileWidth,
                  tileHeight;

    private Dictionary<Vector2, GridTile> tiles = new Dictionary<Vector2, GridTile>();

	// Update is called once per frame
	void Start () {



        tileWidth = Screen.width / gridWidth;
        tileHeight = Screen.height / gridHeight;

        //GridOverlay overlay = gameObject.AddComponent<GridOverlay>();
        //overlay.Configure(gridWidth, gridWidth, tileWidth, tileHeight);

        for (int i = 0; i < gridWidth; i++)
        {
            for(int j = 0; j > gridHeight; j++)
            {
                tiles.Add(new Vector2(i, j), new GridTile(i, j));

            }
        }
	}
}
