using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGroup : MonoBehaviour {

    private Color32 _color;
    public Color32 color
    {
        get
        {
            return this._color;
        }
        set
        {
            _color = value;
        }
    }

    private UnitInfo _unit;
    public UnitInfo info
    {
        get
        {
            return this._unit;
        }
        set
        {
            _unit = value;
        }
    }

    private UnitType _type;

    public UnitType type
    {
        get
        {
            return this._type;
        }
        set
        {
            _type = value;
        }
    }

    private Vector2 _gridPosition;
    public Vector2 gridPosition
    {
        get
        {
            return this._gridPosition;
        }
        set
        {
            _gridPosition = value;
        }
    }
}
