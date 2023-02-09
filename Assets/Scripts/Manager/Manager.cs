using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public static Manager instance;

    [HideInInspector] public Save save;

    public List<Quest> allQuests;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
            save = new Save();
            save.quests = new List<Quest>(allQuests);
        }else{
            Destroy(gameObject);
        }
    }

    public Save GetSave(){
        return save;
    }

    public List<Quest> getQuestsInProgress(){
        List<Quest> res = new List<Quest>();
        foreach(Quest q in save.quests){
            if(q.status == Quest.Status.IN_PROGRESS){
                res.Add(q);
            }
        }
        return res;
    }

    public void RefreshAllQuestDialogTriggers(){
        QuestDialogTrigger[] triggers = FindObjectsOfType(typeof(QuestDialogTrigger)) as QuestDialogTrigger[];

        foreach(QuestDialogTrigger trigger in triggers){
            trigger.HideMark();
        }
        foreach(QuestDialogTrigger trigger in triggers){
            trigger.RefreshIfAvailable();
        }
    }

    public void StartQuest(int questIndex){
        save.quests[questIndex].status = Quest.Status.IN_PROGRESS;
    }

    public void FinishQuest(int questIndex){
        save.quests[questIndex].status = Quest.Status.DONE;
        if(save.quests[questIndex].nextQuest != -1 && 
            save.quests[save.quests[questIndex].nextQuest].status == Quest.Status.NOT_AVAILABLE
        ){
            save.quests[save.quests[questIndex].nextQuest].status = Quest.Status.AVAILABLE;
        }
        AddExp(save.quests[questIndex].expReward);
    }

    public void IncrementQuestProgress(int questIndex){
        save.quests[questIndex].questProgress++;
    }

    public int GetArmorValue(){
        return 0;
    }

    public void AddExp(int value){
        save.exp += value;
        while(save.exp >= save.expToNext){
            save.exp-= save.expToNext;
            GetLevel();
        }
    }

    void GetLevel(){
        save.level++;
        save.expToNext+=10;
    }


    public bool TakeDamage(int dmg){
        save.currHealth -= Mathf.Clamp(0,dmg,dmg-GetArmorValue());

        return save.currHealth <= 0;
    }


    public void ChangeLevel(string levelName,Vector3 woldMapPos){
        Time.timeScale = 1;
        save.currentMap = levelName;
        if(woldMapPos != Vector3.zero){
            save.worldMapPos = woldMapPos;
        }
        SceneManager.LoadScene(levelName);
    }


    public void SaveGame(Vector3 playerPosition,int saveIndex){
        if(save.currentMap != "WorldMap"){
            save.mapPos = playerPosition;
            save.mapRotation = GameObject.Find("/Player").transform.eulerAngles;
        }else{
            save.worldMapPos = playerPosition;
        }
        FileManager.SaveJSON(FileManager.savPath + "Saves/save"+saveIndex.ToString()+".sav",save);
    }

    public void LoadGame(int saveIndex){
        if(!System.IO.File.Exists(FileManager.savPath + "Saves/save"+saveIndex.ToString()+".sav")) return;

        save = FileManager.LoadJSON<Save>(FileManager.savPath + "Saves/save"+saveIndex.ToString()+".sav");

        if(save.quests.Count != allQuests.Count){
            for(int i = save.quests.Count;i<allQuests.Count;i++){
                save.quests.Add(allQuests[i]);
            }
        }

        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync(){
        AsyncOperation load = SceneManager.LoadSceneAsync(save.currentMap);

        while(!load.isDone){
            yield return new WaitForEndOfFrame();
        }

        if(save.currentMap != "WorldMap"){
            GameObject.Find("/Player").GetComponent<PlayerMovements>().Teleport(save.mapPos,save.mapRotation);
        }
    }

    public void ResetSave(){
        save = new Save();
        save.quests = new List<Quest>(allQuests);
    }
}
