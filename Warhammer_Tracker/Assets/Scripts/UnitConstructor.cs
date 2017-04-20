using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UnitConstructor : MonoBehaviour {

    public List<string> units;
    public Dropdown dropdown;
    public Text selectedUnit;
    public GameObject panel;
    private GameObject _active;
    private UnitManager _uManager;
    private UnitFactory _UFactory;

    public void SetActiveUnit(GameObject group)
    {
        _active = group;
        panel.SetActive(true);
    }

    // DvdS: Function after a unit is selected, insert here the good stuff
    public void DropdownChange(int index) {
        // DvdS: 0 is -select-
        if (index != 0) {
            selectedUnit.text = units[index];
            UnitGroup ug = _active.GetComponent<UnitGroup>();
            ug.type = (UnitType)System.Enum.Parse(typeof(UnitType), selectedUnit.text);
            _active.name = "Unit: " + ug.type.ToString();
            ug.info = _uManager.GetUnitInfoByType(ug.type);
            _UFactory.AddUnit(ug);
            selectedUnit.color = ug.color;
        } else {
            selectedUnit.text = "You didn't select a unit";
            selectedUnit.color = Color.red;
        }
    }

	void Start () {
        panel.SetActive(false);
        _uManager = Hierarchy.GetComponentWithTag<UnitManager>("UnitManager");
        _UFactory = Hierarchy.GetComponentWithTag<UnitFactory>("UnitManager");
        FillList();
        selectedUnit.text = "";
    }

    void FillList () {
        string[] unitNames = Enum.GetNames(typeof(UnitType));

        units = new List<string>();
        foreach (string name in unitNames) {
            //string newName = name.Replace("_", " ");
            units.Add(name);
        }
        units.Insert(0, "-select-");

        dropdown.AddOptions(units);
    }
}
