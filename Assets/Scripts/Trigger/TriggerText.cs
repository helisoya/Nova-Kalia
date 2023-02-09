using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : Trigger
{
    [SerializeField] private string textToShow;

     public override void Activate(){
        DialogsUI.instance.ShowText(textToShow);
    }

    public override void Desactivate(){
        DialogsUI.instance.HideText();
    }
}
