using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKillAllEnnemies : Trigger
{
    [SerializeField] private int nbEnnemies;
    [SerializeField] private int questIndex;
    [SerializeField] private int questProgress;
    public override void Activate(){
        nbEnnemies--;
        if(nbEnnemies <= 0){
            if(Manager.instance.save.quests[questIndex].status == Quest.Status.IN_PROGRESS &&
                Manager.instance.save.quests[questIndex].questProgress == questProgress){
                    Manager.instance.IncrementQuestProgress(questIndex);
                    Manager.instance.RefreshAllQuestDialogTriggers();
            }
        }
    }

    public override void Desactivate()
    {
        throw new System.NotImplementedException();
    }
}
