using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageInfo
{
    public Color32 color;
    public string message;

    public MessageInfo(Color32 color, string message)
    {
        this.color = color;
        this.message = message;
    }
}

public class LogController : MonoBehaviour {

    public List<MessageInfo> messages = new List<MessageInfo>();
    public string message;
    public Text message1;
    public Text message2;
    public Text message3;
    public Text message4;
    public Text message5;

    public Text unitTitle;
    public Text equipment;
    public Text stats;
    public Text mount;

    public void addMessages(Vector2 gridPosition, UnitGroup unit)
    {
        message = unit.type + " moved to " + gridPosition;
        messages.Add(new MessageInfo(unit.color, message));

        updateMessages(messages);
    }

    public void updateMessages(List<MessageInfo> messages)
    {
        message5.text = messages[messages.Count - 1].message;
        message5.color = messages[messages.Count - 1].color;
        message4.text = messages[messages.Count - 2].message;
        message4.color = messages[messages.Count - 2].color;
        message3.text = messages[messages.Count - 3].message;
        message3.color = messages[messages.Count - 3].color;
        message2.text = messages[messages.Count - 4].message;
        message2.color = messages[messages.Count - 4].color;
        message1.text = messages[messages.Count - 5].message;
        message1.color = messages[messages.Count - 5].color;
    }

    public void updateStats(UnitInfo unit)
    {
        string title = unit.type.ToString();
        unitTitle.text = title;

        string items = "";
        foreach(string item in unit.equipment)
        {
            items += item + "\n";
        }
        equipment.text = items;

        stats.text = "Movement: " + unit.movement + "\n" +
                     "Weapon Skill: " + unit.weaponSkill + "\n" +
                     "Ballistic Skill: " + unit.ballisticSkill + "\n" +
                     "Toughness: " + unit.toughness + "\n" +
                     "Strength: " + unit.strength + "\n" +
                     "Wounds: " + unit.wounds + "\n" +
                     "Initiative: " + unit.initiative + "\n" +
                     "Attacks: " + unit.attack + "\n" +
                     "Leadership: " + unit.leadership + "\n";

        mount.text = unit.mount[0].ToString();
    }
}
