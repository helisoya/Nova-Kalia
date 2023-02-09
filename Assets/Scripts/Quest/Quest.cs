using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{

    public enum Status
    {
        NOT_AVAILABLE,
        AVAILABLE,
        IN_PROGRESS,
        DONE
    }

    public Status status;
    public int questProgress;
    public string questName;
    public string questDescription;
    public int expReward;
    public string[] questObjectives;
    public int nextQuest;

    public Quest(){
        status = Status.NOT_AVAILABLE;
        questProgress = 0;
        questName = "AAAAA";
        questDescription = "slt";
        expReward = 10;
        nextQuest = -1;
    }

}
