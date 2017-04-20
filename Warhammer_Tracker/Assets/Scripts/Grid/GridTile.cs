using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile  {

    public Vector2 position;
    public UnitGroup unit;

	public GridTile(float x, float y)
    {
        this.position = new Vector2(x, y);
    }

    
}
