using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {
   
	public List<UnitCollection> unitTypes = new List<UnitCollection>();

    public UnitInfo GetUnitInfoByType(UnitType type)
    {
        foreach (UnitCollection uc in unitTypes)
        {
            if (uc.type == type)
                return uc.info;
        }

        return null;
    }
}
