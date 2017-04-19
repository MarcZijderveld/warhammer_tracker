using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType {
	Phoenix_Guard,
	Sisters_of_Avalorn
}

[System.Serializable]
public class UnitInfo : MonoBehaviour {
	public List<string> equipment = new List<string> ();
	public List<string> specialRules = new List<string>();
	public UnitType type;
	public int	movement,
				weaponSkill,
				ballisticSkill,
				strenght,
				toughness,
				wounds,
				initiative,
				attack,
				leadership;
}
