using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MenuUITab
{

    [SerializeField] private GameObject prefabQuestButton;
    [SerializeField] private Transform parentQuestButtons;
    [SerializeField] private Text currentQuestDesc;
    [SerializeField] private Text currentQuestReward;


    public override void OpenTab(){
        rootTab.SetActive(true);


        for (int i = parentQuestButtons.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(parentQuestButtons.GetChild(i).gameObject);
        }

        List<Quest> quests = Manager.instance.getQuestsInProgress();
        foreach(Quest q in quests){
            GameObject but = Instantiate(prefabQuestButton,parentQuestButtons);
            but.GetComponentInChildren<Text>().text = q.questName;
            but.GetComponent<Button>().onClick.AddListener(() => {UpdateDescription(q);});
        }

        if(quests.Count != 0){
            UpdateDescription(quests[0]);
        }else{
            currentQuestDesc.text = "";
            currentQuestReward.text = "";
        }
    }

    void UpdateDescription(Quest q){
        currentQuestDesc.text = q.questName+"\n\n"+q.questDescription+"\n\n"+q.questObjectives[q.questProgress];
        currentQuestReward.text = "Récompense : "+q.expReward+" exp";
    }
}
