using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WorldMapUI : MonoBehaviour
{
    public static WorldMapUI instance;

    [SerializeField] private Transform player;

    void Awake(){
        instance = this;
    }

    [SerializeField] private GameObject locationTab;
    [SerializeField] private Text locationNameText;
    private string nextLocation;


    public void ShowLocationTab(string locationName,string nextLevel){
        nextLocation = nextLevel;
        locationTab.SetActive(true);
        locationNameText.text = locationName;
    }

    public void HideLocationTab(){
        locationTab.SetActive(false);
    }

    public void GoToLocation(){
        Manager.instance.ChangeLevel(nextLocation,player.position);
    }

}
