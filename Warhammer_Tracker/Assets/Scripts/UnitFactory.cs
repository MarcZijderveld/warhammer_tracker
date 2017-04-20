using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour {

    private List<UnitGroup> _activeUnits = new List<UnitGroup>();
    private UnitConstructor _dropdown;
    private GridManager _gManager;
    private LogController _logController;

    private void Start()
    {
        _dropdown = Hierarchy.GetComponentWithTag<UnitConstructor>("DropDownController");
        _gManager = Hierarchy.GetComponentWithTag<GridManager>("GridManager");
        _logController = Hierarchy.GetComponentWithTag<LogController>("LogController");
    }

    public void CreateUnit(Color32 color)
    {
        GameObject go = new GameObject();
        UnitGroup ug = go.AddComponent<UnitGroup>();

        ug.color = color;
        _dropdown.SetActiveUnit(go, false);
    }

    public void AddUnit(UnitGroup unit)
    {
        _activeUnits.Add(unit);
    }

    public void UpdateUnit(Color32 color, Vector3 position)
    {
        foreach(UnitGroup ug in _activeUnits)
        {
            if(ug.color.Equals(color))
            {
                if(ug.gridPosition != _gManager.GetGridPos(position))
                {
                    ug.gridPosition = _gManager.GetGridPos(position);
                    _gManager.SetGridUnit(ug.gridPosition, ug);
                   
                    _logController.addMessages(ug.gridPosition, ug.type);
                }
            }
        }
    }

    public void UpdateUnit(Color32 color, UnitType type)
    {
        foreach (UnitGroup ug in _activeUnits)
        {
            if (ug.color.Equals(color))
            {
                if (ug.type != type)
                {
                    ug.type = type;
                    _gManager.SetGridUnit(ug.gridPosition, ug);
                }
            }
        }
    }
}
