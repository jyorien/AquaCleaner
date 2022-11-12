using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC 
{
   public string Name { get; }
   public Dialog[] Dialogs { get; }
    public NPC(string name, Dialog[] dialogs)
    {
        Name = name;
        Dialogs = dialogs;
    }
}



public class Dialog
{
    public string _text { get; }
    public bool _isNPC { get; }
    public string _buttonName { get; }

    public delegate void ButtonAction();
    public ButtonAction _buttonAction { get; }

    public Dialog(string text, bool isNPC, string buttonName, ButtonAction buttonAction)
    {
        _text = text;
        _isNPC = isNPC;
        _buttonName = buttonName;
        _buttonAction = buttonAction;
    }
}