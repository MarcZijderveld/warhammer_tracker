using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogController : MonoBehaviour {

    public List<string> messages = new List<string>();
    public string message;
    public Text message1;
    public Text message2;
    public Text message3;
    public Text message4;
    public Text message5;

    public void addMessages(Vector2 gridPosition, UnitType type)
    {
        message = type + " moved to " + gridPosition;
        messages.Add(message);

        updateMessages(messages);
    }

    public void updateMessages(List<string> messages)
    {
        string test = messages[messages.Count - 1];
        
        message5.text = test;

        //DvdS: Dit is het uiteindelijke idee
        /*message5.text = messages[messages.Count - 1];
        message4.text = messages[messages.Count - 2];
        message3.text = messages[messages.Count - 3];
        message2.text = messages[messages.Count - 4];
        message1.text = messages[messages.Count - 5];*/
    }
}
