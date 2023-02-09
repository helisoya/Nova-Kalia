using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndQuest : Trigger
{
    [SerializeField] private string endDialog;

    [SerializeField] private int questIndex;

    public override void Activate(){
        DialogsUI.instance.ShowEndQuest(questIndex,endDialog);
    }

    public override void Desactivate(){
        DialogsUI.instance.HideEndQuest();
    }
}
