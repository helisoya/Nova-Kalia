using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogTrigger : DialogTrigger
{
    [SerializeField] private int questIndex;
    [SerializeField] private int triggerForQuestProgress;
    [SerializeField] private Quest.Status triggerForStatus;

    private bool allGood;

    void Start(){
        allGood = false;
        RefreshIfAvailable();
    }

    public void HideMark(){
        mark.SetActive(false);
    }


    public void RefreshIfAvailable(){
        Save save = Manager.instance.GetSave();
        
        if(save.quests[questIndex].status == triggerForStatus && 
        triggerForQuestProgress == save.quests[questIndex].questProgress){
            allGood = true;
            mark.SetActive(true);
        }else{
            allGood = false;
        }

    }

    void OnTriggerEnter(Collider col){
        if(allGood && col.tag == "Player"){
            whatToEnable.Activate();
        }
    }

    void OnTriggerExit(Collider col){
        if(allGood && col.tag == "Player"){
            whatToEnable.Desactivate();
        }
    }
}
