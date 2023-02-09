using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerContinueQuest : Trigger
{
    [SerializeField] private string dialog;

    [SerializeField] private int questIndex;

    public override void Activate(){
        DialogsUI.instance.ShowContinueQuest(questIndex,dialog);
    }

    public override void Desactivate(){
        DialogsUI.instance.HideContinueQuest();
    }
}