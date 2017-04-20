using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType {
	Phoenix_Guard,
	Sisters_of_Avelorn,
    Swordmasters_of_Hoeth,
    Silver_Helms,
    Shadow_Warriors,
    Zombies,
    Skeleton_Warriors,
    Black_Knights,
    Spirit_Host,
    Hexwraiths
}

[System.Serializable]
public class UnitCollection
{
    public UnitType type;
    public UnitInfo info;
}

[System.Serializable]
public class UnitInfo : MonoBehaviour {
	public List<string> equipment = new List<string> ();
    public List<string> mount = new List<string>();
    public List<string> specialRules = new List<string>();
	public UnitType type;
	public int	movement,
				weaponSkill,
				ballisticSkill,
				strength,
				toughness,
				wounds,
				initiative,
				attack,
				leadership;

  
}