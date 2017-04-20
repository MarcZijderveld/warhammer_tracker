using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour {

    private List<UnitGroup> _activeUnits = new List<UnitGroup>();
    private UnitConstructor _dropdown;

    private void Start()
    {
        _dropdown = Hierarchy.GetComponentWithTag<UnitConstructor>("DropDownController");
    }

    public void CreateUnit(Color32 color)
    {
        GameObject go = new GameObject();
        UnitGroup ug = go.AddComponent<UnitGroup>();

        ug.color = color;
        _dropdown.SetActiveUnit(go);
    }

    public void AddUnit(UnitGroup unit)
    {
        _activeUnits.Add(unit);
    }
}
