using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogsUI : MonoBehaviour
{

    public static DialogsUI instance;

    void Start(){
        instance = this;
    }

    [SerializeField] private GameObject dialogTab;
    [SerializeField] private Text dialogTabText;
    [SerializeField] private GameObject acceptQuestTab;
    [SerializeField] private Text acceptQuestTabText;
    [SerializeField] private GameObject endQuestTab;
    [SerializeField] private Text endQuestTabText;

    [SerializeField] private GameObject continueQuestTab;
    [SerializeField] private Text continueQuestText;
    private int currentQuest;

    public void ShowText(string txt){
        dialogTab.SetActive(true);
        dialogTabText.text = txt.Replace("\n",Manager.instance.save.playerName);
    }

    public void HideText(){
        dialogTab.SetActive(false);
    }

    public void ShowAcceptQuest(int questId,string txt){
        currentQuest = questId;
        acceptQuestTab.SetActive(true);
        acceptQuestTabText.text = txt.Replace("\n",Manager.instance.save.playerName)+"\n\nRécompense : "+Manager.instance.GetSave().quests[currentQuest].expReward.ToString()+" exp";
    }

    public void HideAcceptQuest(){
        acceptQuestTab.SetActive(false);
    }

    public void ShowEndQuest(int questId,string txt){
        currentQuest = questId;
        endQuestTab.SetActive(true);
        endQuestTabText.text = txt.Replace("\n",Manager.instance.save.playerName)+"\n\nRécompense : "+Manager.instance.GetSave().quests[currentQuest].expReward.ToString()+" exp";
    }

    public void HideEndQuest(){
        endQuestTab.SetActive(false);
    }

    public void ShowContinueQuest(int questId,string txt){
        currentQuest = questId;
        continueQuestTab.SetActive(true);
        continueQuestText.text = txt.Replace("\n",Manager.instance.save.playerName);
    }

    public void HideContinueQuest(){
        continueQuestTab.SetActive(false);
    }

    public void EndQuest(){
        Manager.instance.FinishQuest(currentQuest);
        Manager.instance.RefreshAllQuestDialogTriggers();
        PlayerUI.instance.RefreshPlayerLevel();
        HideEndQuest();
    }

    public void StartQuest(){
        Manager.instance.StartQuest(currentQuest);
        Manager.instance.RefreshAllQuestDialogTriggers();
        HideAcceptQuest();
    }

    public void ContinueQuest(){
        Manager.instance.IncrementQuestProgress(currentQuest);
        Manager.instance.RefreshAllQuestDialogTriggers();
        HideContinueQuest();
    }
}
