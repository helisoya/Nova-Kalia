using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public string currentMap;
    public Vector3 worldMapPos;
    public Vector3 mapPos;
    public Vector3 mapRotation;

    public string playerName;

    public int level;

    public int exp;

    public int expToNext;

    public int currHealth;

    public int maxHealth; 

    public List<Quest> quests;

    public Save(){
        currentMap = "WorldMap";
        worldMapPos = Vector3.zero;
        mapPos = new Vector3();
        mapRotation = Vector3.zero;
        playerName = "Billy";
        level = 1;
        exp = 0;
        expToNext = 20;
        currHealth = 30;
        maxHealth = 30;
    }

}
