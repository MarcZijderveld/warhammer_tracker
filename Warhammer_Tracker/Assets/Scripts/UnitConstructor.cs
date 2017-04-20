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
    public RawImage selectedColor;
    public GameObject panel_constructor;
    public GameObject panel_log;
    private GameObject _active;
    private UnitManager _uManager;
    private UnitFactory _UFactory;

    public void SetActiveUnit(GameObject group)
    {
        _active = group;
        panel_constructor.SetActive(true);
    }

	void Start ()
    {
        panel_constructor.SetActive(false);
        panel_log.SetActive(false);
        _uManager = Hierarchy.GetComponentWithTag<UnitManager>("UnitManager");
        _UFactory = Hierarchy.GetComponentWithTag<UnitFactory>("UnitManager");
        FillList();
        selectedUnit.text = "";
        selectedColor.enabled = false;
    }

    void FillList ()
    {
        string[] unitNames = Enum.GetNames(typeof(UnitType));

        units = new List<string>();
        foreach (string name in unitNames) {
            //DvdS: Voor de mooi, werkend maken als er tijd is
            //string newName = name.Replace("_", " ");
            //units.Add(newName);
            units.Add(name);
        }
        units.Insert(0, "-select-");

        dropdown.AddOptions(units);
    }

    //DvdS: Feedback when color get selected
    public void ColorSelected(Color32 color)
    {
        if (selectedColor.enabled == false)
        {
            selectedColor.enabled = true;
        }
        selectedColor.color = color;
    }

    // DvdS: Function after a unit is selected, insert here the good stuff
    public void DropdownChange(int index)
    {
        // DvdS: 0 is -select-
        if (index != 0)
        {
            selectedUnit.text = units[index];
            UnitGroup ug = _active.GetComponent<UnitGroup>();
            ug.type = (UnitType)System.Enum.Parse(typeof(UnitType), selectedUnit.text);
            _active.name = "Unit: " + ug.type.ToString();
            ug.info = _uManager.GetUnitInfoByType(ug.type);
            _UFactory.AddUnit(ug);
            selectedUnit.color = ug.color;
        }
        else
        {
            selectedUnit.text = "You didn't select a unit";
            selectedUnit.color = Color.red;
        }
    }

    public void StartGame()
    {
        //DvdS: Something which will initialize the actual tracking?

        panel_constructor.SetActive(false);
        panel_log.SetActive(true);
    }
    
    //DvdS: Has this to be here?
    public void UpdateLog()
    {
        //Unit
        //Endposition 
    }
}
