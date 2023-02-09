using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBeginQuest : Trigger
{
    [SerializeField] private string questDescription;

    [SerializeField] private int questIndex;

    public override void Activate(){
        DialogsUI.instance.ShowAcceptQuest(questIndex,questDescription);
    }

    public override void Desactivate(){
        DialogsUI.instance.HideAcceptQuest();
    }
}
