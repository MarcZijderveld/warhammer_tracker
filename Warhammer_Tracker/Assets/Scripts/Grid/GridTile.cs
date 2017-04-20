using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour {

    private Vector2 position;
    private UnitGroup unit;

	public GridTile(float x, float y)
    {
        this.position = new Vector2(x, y);
    }
}
