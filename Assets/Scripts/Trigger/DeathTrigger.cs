using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : Trigger
{

    [SerializeField] private int questIndex;
    [SerializeField] private int triggerForQuestProgress;


    public override void Activate(){
        Save save = Manager.instance.GetSave();
        if(triggerForQuestProgress == save.quests[questIndex].questProgress
        && save.quests[questIndex].status == Quest.Status.IN_PROGRESS){
            Manager.instance.IncrementQuestProgress(questIndex);
            Manager.instance.RefreshAllQuestDialogTriggers();
        }
    }

    public override void Desactivate()
    {
        throw new System.NotImplementedException();
    }
}
